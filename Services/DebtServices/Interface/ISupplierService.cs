using Maksby.Contract.Supplier;

namespace Maksby.Services.DebtServices.Interface;

public interface ISupplierService
{

      Task<Guid> AddSupplier(AddSupplierRequest SupplierRequest, CancellationToken cancellationToken);
      Task<Guid> EditSupplier(Guid id, AddSupplierRequest SupplierRequest, CancellationToken cancellationToken);
      Task<GetSupplierRequest> GetSupplier(Guid id, CancellationToken cancellationToken);
      Task<List<GetSupplierRequest>> GetSuppliers(CancellationToken cancellationToken);
}
