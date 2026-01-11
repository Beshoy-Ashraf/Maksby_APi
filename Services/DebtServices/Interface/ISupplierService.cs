using Maksby.Contract.Supplier;

namespace Maksby.Services.DebtServices.Interface;

public interface ISupplierService
{

      Task<Guid> AddSupplier(SupplierRequest SupplierRequest, CancellationToken cancellationToken);
      Task<Guid> EditSupplier(Guid id, SupplierRequest SupplierRequest, CancellationToken cancellationToken);
      Task<SupplierRequest> GetSupplier(Guid id, CancellationToken cancellationToken);
      Task<List<SupplierRequest>> GetSuppliers(CancellationToken cancellationToken);
}
