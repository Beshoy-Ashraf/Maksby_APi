using Maksby.Contract.SupplierTransactions;
using Maksby.Data.Context;
using Maksby.Data.Models.Debt;
using Maksby.Services.SupplierTransactionServices.Interface;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Services.SupplierTransactionServices;

public class SupplierTransactionServices : ISupplierTransactionServices
{
      private readonly AppDBContext _dbContext;
      private readonly IServiceProvider _serviceProvider;
      private readonly ILogger<SupplierTransactionServices> _logger;

      public SupplierTransactionServices(AppDBContext dbContext, IServiceProvider serviceProvider, ILogger<SupplierTransactionServices> logger)
      {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            _logger = logger;
      }
      public async Task<Guid> AddSupplierTransaction(AddSupplierTransactionRequest addSupplierTransactionRequest, CancellationToken cancellationToken)
      {
            var Supplier = await _dbContext.Suppliers.FirstAsync(x => x.Id == addSupplierTransactionRequest.SupplierId, cancellationToken);
            var invoice = await _dbContext.DebtInvoices
              .Include(s => s.Supplier)
              .Include(d => d.DebtInvoiceItems)
              .ThenInclude(i => i.Item)
              .FirstOrDefaultAsync(x => x.Id == addSupplierTransactionRequest.InvoiceId, cancellationToken)
              ?? throw new KeyNotFoundException($"Invoice with ID {addSupplierTransactionRequest.InvoiceId} was not found.");
            if (invoice.OpenAmount - addSupplierTransactionRequest.Amount < 0)
                  throw new InvalidOperationException($"Invoice with ID {addSupplierTransactionRequest.InvoiceId} has open amount less than payment.");

            var transaction = new DebtTransaction
            {
                  Supplier = Supplier,
                  DebtInvoice = invoice,
                  Amount = addSupplierTransactionRequest.Amount,
            };
            invoice.OpenAmount -= addSupplierTransactionRequest.Amount;
            _dbContext.DebtInvoices.Update(invoice);
            await _dbContext.DebtTransactions.AddAsync(transaction, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return transaction.Id;
      }
      public async Task RefundSupplierTransaction(Guid id, CancellationToken cancellationToken)
      {
            var SupplierTransaction = await _dbContext.DebtTransactions
            .Include(i => i.DebtInvoice)
            .Include(c => c.Supplier)
            .FirstAsync(x => x.Id == id, cancellationToken) ?? throw new KeyNotFoundException($"Transaction with ID {id} was not found.");

            SupplierTransaction.DebtInvoice.OpenAmount += SupplierTransaction.Amount;
            _dbContext.DebtInvoices.Update(SupplierTransaction.DebtInvoice);
            _dbContext.DebtTransactions.Remove(SupplierTransaction);
            await _dbContext.SaveChangesAsync(cancellationToken);
      }
      public async Task<GetSupplierTransactionRequest> GetTransaction(Guid id, CancellationToken cancellationToken)
      {
            var SupplierTransaction = await _dbContext.DebtTransactions
           .Include(i => i.DebtInvoice)
           .Include(c => c.Supplier)
           .FirstAsync(x => x.Id == id, cancellationToken) ?? throw new KeyNotFoundException($"Transaction with ID {id} was not found.");

            var response = new GetSupplierTransactionRequest
            {
                  Id = SupplierTransaction.Id,
                  SupplierId = SupplierTransaction.Supplier.Id,
                  InvoiceId = SupplierTransaction.DebtInvoice.Id,
                  Amount = SupplierTransaction.Amount,
                  Date = SupplierTransaction.Date,
                  OpenAmount = SupplierTransaction.DebtInvoice.OpenAmount
            };
            return response;

      }
      public async Task<List<GetSupplierTransactionRequest>> GetSuppliersTransactions(CancellationToken cancellationToken)
      {
            var SupplierTransactions = await _dbContext.DebtTransactions
               .Include(i => i.DebtInvoice)
               .Include(c => c.Supplier)
               .Select(x => new GetSupplierTransactionRequest
               {
                     Id = x.Id,
                     SupplierId = x.Supplier.Id,
                     InvoiceId = x.DebtInvoice.Id,
                     Amount = x.Amount,
                     Date = x.Date,
                     OpenAmount = x.DebtInvoice.OpenAmount,
               })
               .ToListAsync(cancellationToken);
            return SupplierTransactions;

      }
      public async Task<List<GetSupplierTransactionRequest>> GetInvoiceTransactions(Guid id, CancellationToken cancellationToken)
      {
            var SupplierTransactions = await _dbContext.DebtTransactions
               .Include(i => i.DebtInvoice)
               .Include(c => c.Supplier)
               .Where(n => n.DebtInvoice.Id == id)
               .Select(x => new GetSupplierTransactionRequest
               {
                     Id = x.Id,
                     SupplierId = x.Supplier.Id,
                     InvoiceId = x.DebtInvoice.Id,
                     Amount = x.Amount,
                     Date = x.Date
               })
               .ToListAsync(cancellationToken);
            return SupplierTransactions;

      }
}
