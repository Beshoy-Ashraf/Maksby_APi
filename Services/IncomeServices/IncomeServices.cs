using System.Collections;
using System.Linq;
using Maksby.Contract;
using Maksby.Contract.Income;
using Maksby.Data.Context;
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
                            Quantity = i.Quantity
                      }).ToList()
                }
                )
                .ToListAsync(cancellationToken);

            return tmp;
      }
      public async Task<List<GetInvoicesResponse>> GetInvoice(Guid Id, CancellationToken cancellationToken)
      {
            var tmp = await _dbContext.ClientInvoices.Where(x => x.Id == Id)
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
                            Quantity = i.Quantity
                      }).ToList()
                }
                )
                .ToListAsync(cancellationToken);

            return tmp;
      }
      public async Task<Guid> EditInvoice(AddInvoiceRequest addInvoiceRequest, Guid Id, CancellationToken cancellationToken)
      {
            var tmp = await _dbContext
                            .ClientInvoices
                            .Where(i => i.Id == Id)
                            .Include(cip => cip.ClientInvoiceProducts)
                            .ThenInclude(p => p.Product)
                            .ToListAsync(cancellationToken);


            var client = await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == addInvoiceRequest.ClientId, cancellationToken);

            if (client is null)
                  throw new Exception();


            var products = await _dbContext.Products
            .Where(p => addInvoiceRequest
                       .ClientInvoiceProductItem
                       .Any(i => i.ProductId == p.Id && i.Quantity <= p.Quantity)).ToListAsync(cancellationToken);

            foreach (var ele in products)
                  ele.Quantity += tmp.First().ClientInvoiceProducts.First().Product.Quantity;


            if (products.Count != addInvoiceRequest.ClientInvoiceProductItem.Count)
                  throw new Exception(); var summary = await _dbContext.Summaries.FirstAsync(cancellationToken);
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
                  ele.Quantity -= item.Quantity;
                  var invoiceProduct = new ClientInvoiceProduct
                  {
                        Product = ele,
                        ClientInvoice = invoice,
                        Quantity = item.Quantity,
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

      public async Task<Guid> Add(AddInvoiceRequest addInvoiceRequest, CancellationToken cancellationToken)
      {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == addInvoiceRequest.ClientId, cancellationToken);

            if (client is null)
                  throw new Exception();


            var products = await _dbContext.Products
            .Where(p => addInvoiceRequest
                       .ClientInvoiceProductItem
                       .Any(i => i.ProductId == p.Id && i.Quantity <= p.Quantity)).ToListAsync(cancellationToken);


            if (products.Count != addInvoiceRequest.ClientInvoiceProductItem.Count)
                  throw new Exception(); var summary = await _dbContext.Summaries.FirstAsync(cancellationToken);

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
                  ele.Quantity -= item.Quantity;
                  var invoiceProduct = new ClientInvoiceProduct
                  {
                        Product = ele,
                        ClientInvoice = invoice,
                        Quantity = item.Quantity,
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
