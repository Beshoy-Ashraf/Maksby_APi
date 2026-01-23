using Maksby.Contract.SupplierTransactions;

namespace Maksby.Services.SupplierTransactionServices.Interface;

public interface ISupplierTransactionServices
{
      Task<List<GetSupplierTransactionRequest>> GetInvoiceTransactions(Guid id, CancellationToken cancellationToken);
      Task<List<GetSupplierTransactionRequest>> GetSuppliersTransactions(CancellationToken cancellationToken);
      Task<GetSupplierTransactionRequest> GetTransaction(Guid id, CancellationToken cancellationToken);
      Task RefundSupplierTransaction(Guid id, CancellationToken cancellationToken);
      Task<Guid> AddSupplierTransaction(AddSupplierTransactionRequest addSupplierTransactionRequest, CancellationToken cancellationToken);



}
