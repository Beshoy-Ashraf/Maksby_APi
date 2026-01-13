using Maksby.Contract.Supplier;
using Maksby.Services.DebtServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.SupplierController;


public partial class SupplierController : ControllerBase
{
      [HttpGet("{Id:guid}")]

      public async Task<GetSupplierRequest> GetSupplier([FromRoute] Guid id, CancellationToken cancellationToken)
      {
            return await _services.GetSupplier(id, cancellationToken);
      }
      [HttpGet]

      public async Task<List<GetSupplierRequest>> GetSuppliers(CancellationToken cancellationToken)
      {
            return await _services.GetSuppliers(cancellationToken);
      }


}
