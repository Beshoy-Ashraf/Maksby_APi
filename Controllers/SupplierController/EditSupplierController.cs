using Maksby.Contract.Supplier;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.SupplierController;


public partial class SupplierController : ControllerBase
{
      [HttpPut("{id:guid}")]

      public async Task<Guid> EditSupplier([FromRoute] Guid id, AddSupplierRequest addSupplierRequest, CancellationToken cancellationToken)
      {
            return await _services.EditSupplier(id, addSupplierRequest, cancellationToken);
      }


}
