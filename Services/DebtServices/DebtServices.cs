using Maksby.Contract.Debt;
using Maksby.Data.Context;
using Maksby.Data.Models;
using Maksby.Data.Models.Debt;
using Maksby.Services.DebtServices.Interface;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Services.DebtServices;

public class DebtServices : IDebtServices
{

      private readonly AppDBContext _dbContext;
      private readonly IServiceProvider _serviceProvider;
      private readonly ILogger<DebtServices> _logger;

      public DebtServices(AppDBContext dbContext, IServiceProvider serviceProvider, ILogger<DebtServices> logger)
      {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            _logger = logger;
      }
      public async Task<Guid> AddSupplierInvoice(AddSupplierInvoicesRequest addSupplierInvoicesRequest, CancellationToken cancellationToken)
      {
            var supplier = await _dbContext.Suppliers.FirstOrDefaultAsync(s => s.Id == addSupplierInvoicesRequest.SupplierId, cancellationToken) ?? throw new KeyNotFoundException($"Supplier with ID {addSupplierInvoicesRequest.SupplierId} was not found.");
            var requestedItemIds = addSupplierInvoicesRequest.supplierInvoiceItems.Select(i => i.ItemId).ToList();

            var allItems = await _dbContext.Items
              .Where(i => requestedItemIds.Contains(i.Id))
              .ToListAsync(cancellationToken);

            var items = allItems
               .Where(p => addSupplierInvoicesRequest.supplierInvoiceItems
                   .Any(i => i.ItemId == p.Id && i.QuantityPerKilo <= p.QuantityPerKilo))
               .ToList();

            if (items.Count != addSupplierInvoicesRequest.supplierInvoiceItems.Count)
                  throw new Exception("items invoice Quantity less than exactly items in inventory");

            var summary = await _dbContext.Summaries.FirstOrDefaultAsync(cancellationToken);
            if (summary == null)
            {
                  summary = new Summary();
                  await _dbContext.Summaries.AddAsync(summary, cancellationToken);
            }

            var supplierInvoice = new DebtInvoice
            {
                  Summary = summary,
                  Date = DateTime.UtcNow,
                  Supplier = supplier,

            };

            List<DebtInvoiceItem> debtInvoiceItems = [];

            foreach (var ele in items)
            {
                  var item = addSupplierInvoicesRequest.supplierInvoiceItems.First(x => x.ItemId == ele.Id);
                  supplierInvoice.Amount += item.QuantityPerKilo * ele.PricePerKilo;
                  ele.QuantityPerKilo -= item.QuantityPerKilo;
                  var invoiceItem = new DebtInvoiceItem
                  {
                        PricePerKilo = ele.PricePerKilo,
                        QuantityPerKilo = item.QuantityPerKilo,
                        DebtInvoice = supplierInvoice,
                        Item = ele
                  };
                  debtInvoiceItems.Add(invoiceItem);
            }

            supplierInvoice.DebtInvoiceItems = debtInvoiceItems;

            await _dbContext.DebtInvoices.AddAsync(supplierInvoice, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return supplierInvoice.Id;

      }
      public async Task<Guid> EditSupplierInvoice(Guid id, AddSupplierInvoicesRequest addSupplierInvoicesRequest, CancellationToken cancellationToken)
      {
            var invoice = await _dbContext.DebtInvoices
               .Include(s => s.Supplier)
               .Include(si => si.DebtInvoiceItems)
               .ThenInclude(i => i.Item)
               .FirstOrDefaultAsync(x => x.Id == id, cancellationToken) ?? throw new KeyNotFoundException($"Invoice with ID {id} was not found.");

            if (invoice.Supplier.Id != addSupplierInvoicesRequest.SupplierId)
            {
                  var supplier = await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.Id == addSupplierInvoicesRequest.SupplierId, cancellationToken) ?? throw new KeyNotFoundException($"Client with ID {addSupplierInvoicesRequest.supplierInvoiceItems} was not found.");
                  invoice.Supplier = supplier;
            }
            var requestedItemIds = addSupplierInvoicesRequest.supplierInvoiceItems.Select(i => i.ItemId).ToList();

            var allItems = await _dbContext.Items
              .Where(i => requestedItemIds.Contains(i.Id))
              .ToListAsync(cancellationToken);

            foreach (var returnItems in allItems)
            {
                  var oldestInvoicesItems = invoice.DebtInvoiceItems.First(i => i.Id == returnItems.Id);
                  returnItems.QuantityPerKilo += oldestInvoicesItems.QuantityPerKilo;
            }

            var items = allItems
               .Where(p => addSupplierInvoicesRequest.supplierInvoiceItems
                   .Any(i => i.ItemId == p.Id && i.QuantityPerKilo <= p.QuantityPerKilo))
               .ToList();
            List<DebtInvoiceItem> debtInvoiceItems = [];

            foreach (var ele in items)
            {
                  var item = addSupplierInvoicesRequest.supplierInvoiceItems.First(x => x.ItemId == ele.Id);
                  invoice.Amount += item.QuantityPerKilo * ele.PricePerKilo;
                  ele.QuantityPerKilo -= item.QuantityPerKilo;
                  var invoiceItem = new DebtInvoiceItem
                  {
                        PricePerKilo = ele.PricePerKilo,
                        QuantityPerKilo = item.QuantityPerKilo,
                        DebtInvoice = invoice,
                        Amount = ele.PricePerKilo * item.QuantityPerKilo,
                        Item = ele

                  };
                  debtInvoiceItems.Add(invoiceItem);
            }


            _dbContext.DebtInvoices.Update(invoice);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return invoice.Id;




      }

      public async Task<List<GetSupplierInvoicesRequest>> GetSupplierInvoices(CancellationToken cancellationToken)
      {
            var invoices = await _dbContext.DebtInvoices
               .Include(s => s.Supplier)
               .Include(si => si.DebtInvoiceItems)
               .ThenInclude(i => i.Item)
                .Select(
                x => new GetSupplierInvoicesRequest
                {
                      InvoiceId = x.Id,
                      SupplierId = x.Supplier.Id,
                      InvoiceDate = x.Date,
                      TotalInvoiceAmount = x.Amount,
                      Status = (Contract.Debt.Status)x.Status,
                      ItemDetails = x.DebtInvoiceItems.Select(i => new ItemDetails
                      {
                            Id = i.Id,
                            ItemId = i.Item.Id,
                            ItemName = i.Item.Name,
                            PricePerKilo = i.PricePerKilo,
                            QuantityPerKilo = i.QuantityPerKilo,
                            Amount = i.PricePerKilo * i.QuantityPerKilo
                      }).ToList()
                }
                )
                .ToListAsync(cancellationToken);

            return invoices;
      }
      public async Task<GetSupplierInvoicesRequest> GetSupplierInvoice(Guid id, CancellationToken cancellationToken)
      {
            var invoice = await _dbContext.DebtInvoices
                 .Include(s => s.Supplier)
                 .Include(si => si.DebtInvoiceItems)
                 .ThenInclude(i => i.Item)
                 .FirstOrDefaultAsync(x => x.Id == id, cancellationToken) ?? throw new KeyNotFoundException($"Invoice with ID {id} was not found.");
            var response = new GetSupplierInvoicesRequest
            {
                  InvoiceId = invoice.Id,
                  SupplierId = invoice.Supplier.Id,
                  InvoiceDate = invoice.Date,
                  TotalInvoiceAmount = invoice.Amount,
                  Status = (Contract.Debt.Status)invoice.Status,
                  ItemDetails = [.. invoice.DebtInvoiceItems.Select(i => new ItemDetails
                  {
                        Id = i.Id,
                        ItemId = i.Item.Id,
                        ItemName = i.Item.Name,
                        PricePerKilo = i.PricePerKilo,
                        QuantityPerKilo = i.QuantityPerKilo,
                        Amount = i.PricePerKilo * i.QuantityPerKilo
                  })]

            };

            return response;
      }




}
