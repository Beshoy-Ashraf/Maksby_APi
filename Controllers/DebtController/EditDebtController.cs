using Maksby.Contract.Debt;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.DebtController;

public partial class DebtController : ControllerBase
{
      [HttpPut]
      public async Task<ActionResult<Guid>> EditSupplier([FromRoute] Guid id, [FromBody] AddSupplierInvoicesRequest addSupplierInvoicesRequest, CancellationToken cancellationToken)
      {
            try
            {

                  var invoiceId = await _services.EditSupplierInvoice(id, addSupplierInvoicesRequest, cancellationToken);
                  return Ok(invoiceId);
            }
            catch (KeyNotFoundException e)
            {
                  return NotFound(e.Message);
            }
            catch (Exception e)
            {
                  return BadRequest(e.Message);
            }
      }


}
