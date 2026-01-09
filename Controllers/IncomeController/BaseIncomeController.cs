using Maksby.Contract;
using Maksby.Data.Context;
using Maksby.Data.Models.Debt;
using Maksby.Data.Models.Income;
using Maksby.Services.IncomeServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Controllers.IncomeController;

[Route("api/income-invoices")]
[ApiController]
public partial class IncomeController : ControllerBase
{
      private readonly ILogger<IncomeController> _logger;
      public IIncomeServices _services { get; }

      public IncomeController(ILogger<IncomeController> logger, IIncomeServices services)
      {
            _logger = logger;
            _services = services;
      }



}
