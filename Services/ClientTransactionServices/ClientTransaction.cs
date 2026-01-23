using System.Transactions;
using Maksby.Contract.ClientTransactions;
using Maksby.Contract.Transaction;
using Maksby.Data.Context;
using Maksby.Data.Models.Income;
using Maksby.Services.ClientTransactionServices.Interface;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Services.ClientTransactionServices;

public class ClientTransactionServices : IClientTransactionServices
{

      private readonly AppDBContext _dbContext;
      private readonly IServiceProvider _serviceProvider;
      private readonly ILogger<ClientTransactionServices> _logger;

      public ClientTransactionServices(AppDBContext dbContext, IServiceProvider serviceProvider, ILogger<ClientTransactionServices> logger)
      {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            _logger = logger;
      }

      public async Task<Guid> AddClientTransaction(AddClientTransactionRequest addClientTransactionRequest, CancellationToken cancellationToken)
      {
            var client = await _dbContext.Clients.FirstAsync(x => x.Id == addClientTransactionRequest.ClientId, cancellationToken);
            var invoice = await _dbContext.ClientInvoices
              .Include(ci => ci.Client)
              .Include(ci => ci.ClientInvoiceProducts)
              .ThenInclude(p => p.Product)
              .FirstOrDefaultAsync(x => x.Id == addClientTransactionRequest.InvoiceId, cancellationToken)
              ?? throw new KeyNotFoundException($"Invoice with ID {addClientTransactionRequest.InvoiceId} was not found.");
            if (invoice.OpenAmount - addClientTransactionRequest.Amount < 0)
                  throw new InvalidOperationException($"Invoice with ID {addClientTransactionRequest.InvoiceId} has open amount less than payment.");

            var transaction = new ClientTransaction
            {
                  Client = client,
                  ClientInvoice = invoice,
                  Amount = addClientTransactionRequest.Amount,
            };
            invoice.OpenAmount -= addClientTransactionRequest.Amount;
            _dbContext.ClientInvoices.Update(invoice);
            await _dbContext.ClientTransactions.AddAsync(transaction, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return transaction.Id;
      }
      public async Task RefundClientTransaction(Guid id, CancellationToken cancellationToken)
      {
            var clientTransaction = await _dbContext.ClientTransactions
            .Include(i => i.ClientInvoice)
            .Include(c => c.Client)
            .FirstAsync(x => x.Id == id, cancellationToken) ?? throw new KeyNotFoundException($"Transaction with ID {id} was not found.");

            clientTransaction.ClientInvoice.OpenAmount += clientTransaction.Amount;
            _dbContext.ClientInvoices.Update(clientTransaction.ClientInvoice);
            _dbContext.ClientTransactions.Remove(clientTransaction);
            await _dbContext.SaveChangesAsync(cancellationToken);
      }
      public async Task<GetClientTransactionRequest> GetTransaction(Guid id, CancellationToken cancellationToken)
      {
            var clientTransaction = await _dbContext.ClientTransactions
           .Include(i => i.ClientInvoice)
           .Include(c => c.Client)
           .FirstAsync(x => x.Id == id, cancellationToken) ?? throw new KeyNotFoundException($"Transaction with ID {id} was not found.");

            var response = new GetClientTransactionRequest
            {
                  Id = clientTransaction.Id,
                  ClientId = clientTransaction.Client.Id,
                  InvoiceId = clientTransaction.ClientInvoice.Id,
                  Amount = clientTransaction.Amount,
                  Date = clientTransaction.Date,
                  OpenAmount = clientTransaction.ClientInvoice.OpenAmount
            };
            return response;

      }
      public async Task<List<GetClientTransactionRequest>> GetClientsTransactions(CancellationToken cancellationToken)
      {
            var clientTransactions = await _dbContext.ClientTransactions
               .Include(i => i.ClientInvoice)
               .Include(c => c.Client)
               .Select(x => new GetClientTransactionRequest
               {
                     Id = x.Id,
                     ClientId = x.Client.Id,
                     InvoiceId = x.ClientInvoice.Id,
                     Amount = x.Amount,
                     Date = x.Date,
                     OpenAmount = x.ClientInvoice.OpenAmount,
               })
               .ToListAsync(cancellationToken);
            return clientTransactions;

      }
      public async Task<List<GetClientTransactionRequest>> GetInvoiceTransactions(Guid id, CancellationToken cancellationToken)
      {
            var clientTransactions = await _dbContext.ClientTransactions
               .Include(i => i.ClientInvoice)
               .Include(c => c.Client)
               .Where(n => n.ClientInvoice.Id == id)
               .Select(x => new GetClientTransactionRequest
               {
                     Id = x.Id,
                     ClientId = x.Client.Id,
                     InvoiceId = x.ClientInvoice.Id,
                     Amount = x.Amount,
                     Date = x.Date
               })
               .ToListAsync(cancellationToken);
            return clientTransactions;

      }

}
