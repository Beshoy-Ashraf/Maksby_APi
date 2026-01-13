
using Maksby.Contract;
using Maksby.Services.IncomeServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Controllers.IncomeController;

public partial class IncomeController : ControllerBase
{
      [HttpPost]
      public async Task<ActionResult<Guid>> AddInvoice([FromBody] AddInvoiceRequest addInvoiceRequest, CancellationToken cancellationToken)
      {
            try
            {
                  var invoice = await _services.Add(addInvoiceRequest, cancellationToken);
                  return Ok(invoice);
            }
            catch (Exception e)
            {
                  return BadRequest($"Error occur while adding invoices  : {e}");
            }
      }

}
