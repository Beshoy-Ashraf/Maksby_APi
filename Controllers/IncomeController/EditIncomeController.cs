using Maksby.Contract.Income;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.IncomeController;


public partial class IncomeController : ControllerBase
{

      [HttpPut("{id:guid}")]
      public async Task<ActionResult<Guid>> EditInvoice([FromBody] AddInvoiceRequest addInvoiceRequest, [FromRoute] Guid Id, CancellationToken cancellationToken)
      {
            try
            {
                  var invoice = await _services.EditInvoice(addInvoiceRequest, Id, cancellationToken);
                  return Ok(invoice);
            }
            catch
            {
                  return BadRequest("Error occur while adding invoices ");
            }
      }
}
