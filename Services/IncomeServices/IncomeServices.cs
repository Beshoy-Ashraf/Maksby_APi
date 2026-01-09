using System.Linq;
using Maksby.Contract;
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

      public async Task<List<DebtInvoice>> Get()
      {
            var tmp = await _dbContext.DebtInvoices
                .Include(x => (IEnumerable<DebtInvoiceItem>)x.DebtInvoiceItems!)
                .ThenInclude(x => x.Items)
                //.Select(
                // x => new resp
                // {
                //       h = x.Amount,

                // }
                //)
                .ToListAsync();

            return tmp;
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
