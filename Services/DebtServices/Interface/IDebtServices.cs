using Maksby.Contract.Debt;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Services.DebtServices.Interface;

public interface IDebtServices
{
      Task<Guid> AddSupplierInvoice(AddSupplierInvoicesRequest addSupplierInvoicesRequest, CancellationToken cancellationToken);
      Task<Guid> EditSupplierInvoice(Guid id, AddSupplierInvoicesRequest addSupplierInvoicesRequest, CancellationToken cancellationToken);
      Task<List<GetSupplierInvoicesRequest>> GetSupplierInvoices(CancellationToken cancellationToken);
      Task<GetSupplierInvoicesRequest> GetSupplierInvoice(Guid id, CancellationToken cancellationToken);

}
