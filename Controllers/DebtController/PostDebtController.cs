using Maksby.Contract.Debt;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.DebtController;


public partial class DebtController : ControllerBase
{
      [HttpPost]
      public async Task<ActionResult<Guid>> AddSupplierInvoice([FromBody] AddSupplierInvoicesRequest addSupplierInvoicesRequest, CancellationToken cancellationToken)
      {

            try
            {

                  var invoiceId = await _services.AddSupplierInvoice(addSupplierInvoicesRequest, cancellationToken);
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
