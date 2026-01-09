using Maksby.Contract;
using Maksby.Data.Context;
using Maksby.Data.Models.Debt;
using Maksby.Data.Models.Income;
using Maksby.Services.IncomeServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Controllers.IncomeController;

public partial class IncomeController : ControllerBase
{
      [HttpGet("{id:guid}")]

      public async Task<ActionResult<List<DebtInvoice>>> GetInvoices([FromRoute] Guid id)
      {
            return await _services.Get();
      }

}
