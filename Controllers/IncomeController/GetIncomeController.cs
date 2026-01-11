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
      [HttpGet]

      public async Task<ActionResult<List<GetInvoicesResponse>>> GetInvoices(CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetInvoices(cancellationToken);
            }
            catch (Exception)
            {
                  return NotFound();
            }

      }
      [HttpGet("{id:guid}")]

      public async Task<ActionResult<List<GetInvoicesResponse>>> GetInvoice([FromRoute] Guid Id, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetInvoice(Id, cancellationToken);
            }
            catch (Exception)
            {
                  return NotFound();
            }
      }

}
