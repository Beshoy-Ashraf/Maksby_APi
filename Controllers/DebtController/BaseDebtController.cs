using Maksby.Services.DebtServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.DebtController;

[ApiController]
[Route("api/supplier-invoices")]
public partial class DebtController : ControllerBase
{
      private readonly ILogger<DebtController> _logger;
      public IDebtServices _services { get; }

      public DebtController(ILogger<DebtController> logger, IDebtServices services)
      {
            _logger = logger;
            _services = services;
      }

}
