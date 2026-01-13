using Maksby.Services.SalaryServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.SalaryController;

[Route("api/salary")]
[ApiController]
public partial class SalaryController : ControllerBase
{
      private readonly ILogger<SalaryController> _logger;
      public ISalaryServices _services { get; }

      public SalaryController(ILogger<SalaryController> logger, ISalaryServices services)
      {
            _logger = logger;
            _services = services;
      }

}
