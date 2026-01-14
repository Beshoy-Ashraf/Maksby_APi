using Maksby.Contract.Debt;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.DebtController;

public partial class DebtController : ControllerBase
{
      [HttpGet]
      public async Task<ActionResult<List<GetSupplierInvoicesRequest>>> GetSupplierInvoicesRequests(CancellationToken cancellationToken)
      {
            try
            {

                  var invoices = await _services.GetSupplierInvoices(cancellationToken);
                  return Ok(invoices);
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
      [HttpGet("{id:guid}")]
      public async Task<ActionResult<GetSupplierInvoicesRequest>> GetSupplierInvoice([FromRoute] Guid id, CancellationToken cancellationToken)
      {
            try
            {

                  var invoices = await _services.GetSupplierInvoice(id, cancellationToken);
                  return Ok(invoices);
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
