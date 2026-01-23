using Maksby.Contract.ClientTransactions;
using Maksby.Contract.Transaction;

namespace Maksby.Services.ClientTransactionServices.Interface;

public interface IClientTransactionServices
{
      Task<List<GetClientTransactionRequest>> GetInvoiceTransactions(Guid id, CancellationToken cancellationToken);
      Task<List<GetClientTransactionRequest>> GetClientsTransactions(CancellationToken cancellationToken);
      Task<GetClientTransactionRequest> GetTransaction(Guid id, CancellationToken cancellationToken);
      Task RefundClientTransaction(Guid id, CancellationToken cancellationToken);
      Task<Guid> AddClientTransaction(AddClientTransactionRequest addClientTransactionRequest, CancellationToken cancellationToken);

}
