using Maksby.Contract.Supplier;
using Maksby.Services.DebtServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.SupplierController;


public partial class SupplierController : ControllerBase
{
      [HttpPost]

      public async Task<Guid> AddSupplier([FromBody] SupplierRequest supplierRequest, CancellationToken cancellationToken)
      {
            return await _services.AddSupplier(supplierRequest, cancellationToken);
      }


}
