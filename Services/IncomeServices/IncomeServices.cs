using System.Collections;
using System.Linq;
using Maksby.Contract;
using Maksby.Contract.Income;
using Maksby.Data.Context;
using Maksby.Data.Models;
using Maksby.Data.Models.Debt;
using Maksby.Data.Models.Income;
using Maksby.Services.IncomeServices.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Services.IncomeServices;

public class IncomeServices : IIncomeServices
{
      private readonly AppDBContext _dbContext;
      private readonly IServiceProvider _serviceProvider;
      private readonly ILogger<IncomeServices> _logger;

      public IncomeServices(AppDBContext dbContext, IServiceProvider serviceProvider, ILogger<IncomeServices> logger)
      {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            _logger = logger;
      }

      public async Task<List<GetInvoicesResponse>> GetInvoices(CancellationToken cancellationToken)
      {
            var tmp = await _dbContext.ClientInvoices
                .Include(ci => ci.Client)
                .Include(ci => ci.ClientInvoiceProducts)
                .ThenInclude(p => p.Product)
                .Select(
                x => new GetInvoicesResponse
                {
                      InvoiceId = x.Id,
                      ClientID = x.Client.Id,
                      Date = x.Date,
                      Amount = x.Amount,
                      Status = (Contract.Income.Status)x.Status,
                      InvoiceItems = x.ClientInvoiceProducts.Select(i => new InvoiceItems
                      {
                            Id = i.Id,
                            ProductId = i.Product.Id,
                            ProductName = i.Product.Name,
                            PricePerKilo = i.PricePerKilo,
                            QuantityPerKilo = i.QuantityPerKilo
                      }).ToList()
                }
                )
                .ToListAsync(cancellationToken);

            return tmp;
      }
      public async Task<GetInvoicesResponse> GetInvoice(Guid Id, CancellationToken cancellationToken)
      {
            var invoice = await _dbContext.ClientInvoices
                .Include(ci => ci.Client)
                .Include(ci => ci.ClientInvoiceProducts)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(x => x.Id == Id, cancellationToken) ?? throw new KeyNotFoundException($"Invoice with ID {Id} was not found.");

            var response = new GetInvoicesResponse
            {
                  InvoiceId = invoice.Id,
                  ClientID = invoice.Client.Id,
                  Date = invoice.Date,
                  Amount = invoice.Amount,
                  Status = (Contract.Income.Status)invoice.Status,
                  OpenAmount = invoice.OpenAmount,
                  InvoiceItems = [.. invoice.ClientInvoiceProducts.Select(i => new InvoiceItems
                  {
                        Id = i.Id,
                        ProductId = i.Product.Id,
                        ProductName = i.Product.Name,
                        PricePerKilo = i.PricePerKilo,
                        QuantityPerKilo = i.QuantityPerKilo
                  })]
            };

            return response;
      }
      public async Task<Guid> EditInvoice(AddInvoiceRequest addInvoiceRequest, Guid Id, CancellationToken cancellationToken)
      {
            var invoice = await _dbContext.ClientInvoices
                .Include(ci => ci.Client)
                .Include(ci => ci.ClientInvoiceProducts)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(x => x.Id == Id, cancellationToken) ?? throw new KeyNotFoundException($"Invoice with ID {Id} was not found.");
            if (invoice.Client.Id != addInvoiceRequest.ClientId)
            {
                  var client = await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == addInvoiceRequest.ClientId, cancellationToken) ?? throw new KeyNotFoundException($"Client with ID {addInvoiceRequest.ClientId} was not found.");
                  invoice.Client = client;
            }
            if (invoice.OpenAmount != 0)
            {
                  throw new InvalidOperationException($"Invoice with ID {Id} has open amount should be returned.");

            }



            var requestedProductIds = addInvoiceRequest.ClientInvoiceProductItem.Select(i => i.ProductId).ToList();

            var allProducts = await _dbContext.Products
                .Where(p => requestedProductIds.Contains(p.Id))
                .ToListAsync(cancellationToken);

            var products = allProducts
                .Where(p => addInvoiceRequest.ClientInvoiceProductItem
                    .Any(i => i.ProductId == p.Id && i.QuantityPerKilo <= p.QuantityPerKilo))
                .ToList();

            foreach (var invoiceProduct in invoice.ClientInvoiceProducts)
            {
                  var Products = await _dbContext.Products.FirstAsync(p => p.Id == invoiceProduct.Product.Id, cancellationToken);
                  Products.QuantityPerKilo += invoiceProduct.QuantityPerKilo;

            }


            if (products.Count != addInvoiceRequest.ClientInvoiceProductItem.Count)
                  throw new Exception();

            invoice.Amount = 0;

            var invoiceProducts = new List<ClientInvoiceProduct>();
            foreach (var ele in products)
            {
                  var item = addInvoiceRequest.ClientInvoiceProductItem.First(x => x.ProductId == ele.Id);
                  ele.QuantityPerKilo -= item.QuantityPerKilo;
                  var invoiceProduct = new ClientInvoiceProduct
                  {
                        Product = ele,
                        ClientInvoice = invoice,
                        QuantityPerKilo = item.QuantityPerKilo,
                        PricePerKilo = ele.PricePerKilo,

                  };

                  invoice.Amount += invoiceProduct.TotalAmount;
                  invoiceProducts.Add(invoiceProduct);
            }
            invoice.ClientInvoiceProducts = invoiceProducts;


            _dbContext.ClientInvoices.Update(invoice);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return invoice.Id;
      }

      public async Task<Guid> Add(AddInvoiceRequest addInvoiceRequest, CancellationToken cancellationToken)
      {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == addInvoiceRequest.ClientId, cancellationToken) ?? throw new KeyNotFoundException($"Client with ID {addInvoiceRequest.ClientId} was not found.");

            var requestedProductIds = addInvoiceRequest.ClientInvoiceProductItem.Select(i => i.ProductId).ToList();

            var allProducts = await _dbContext.Products
                .Where(p => requestedProductIds.Contains(p.Id))
                .ToListAsync(cancellationToken);

            var products = allProducts
                .Where(p => addInvoiceRequest.ClientInvoiceProductItem
                    .Any(i => i.ProductId == p.Id && i.QuantityPerKilo <= p.QuantityPerKilo))
                .ToList();


            if (products.Count != addInvoiceRequest.ClientInvoiceProductItem.Count)
                  throw new Exception();

            var summary = await _dbContext.Summaries.FirstOrDefaultAsync(cancellationToken);
            if (summary == null)
            {
                  summary = new Summary();
                  await _dbContext.Summaries.AddAsync(summary, cancellationToken);
            }

            var invoice = new ClientInvoice
            {
                  Summary = summary,
                  Client = client,
                  Amount = 0,
            };

            var invoiceProducts = new List<ClientInvoiceProduct>();

            foreach (var ele in products)
            {
                  var item = addInvoiceRequest.ClientInvoiceProductItem.First(x => x.ProductId == ele.Id);
                  ele.QuantityPerKilo -= item.QuantityPerKilo;
                  var invoiceProduct = new ClientInvoiceProduct
                  {
                        Product = ele,
                        ClientInvoice = invoice,
                        QuantityPerKilo = item.QuantityPerKilo,
                        PricePerKilo = ele.PricePerKilo,

                  };
                  invoice.Amount += invoiceProduct.TotalAmount;
                  invoiceProducts.Add(invoiceProduct);
            }
            invoice.ClientInvoiceProducts = invoiceProducts;


            await _dbContext.ClientInvoices.AddAsync(invoice, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return invoice.Id;
      }
}
