using Maksby.Contract;
using Maksby.Contract.Income;
using Maksby.Data.Context;
using Maksby.Data.Models.Debt;
using Maksby.Data.Models.Income;
using Maksby.Services.IncomeServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Controllers.IncomeController;

public partial class IncomeController : ControllerBase
{
      [HttpGet("{id:Guid}")]

      public async Task<ActionResult<GetInvoicesResponse>> GetInvoice([FromRoute] Guid id, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetInvoice(id, cancellationToken);
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
      [HttpGet]

      public async Task<ActionResult<List<GetInvoicesResponse>>> GetInvoices(CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetInvoices(cancellationToken);
            }
            catch (Exception e)
            {
                  return BadRequest(e);
            }

      }

}
