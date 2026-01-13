using Maksby.Services.DebtServices.Interface;
using Maksby.Services.EmployeeServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.EmployeeController;

[Route("api/employee")]
[ApiController]
public partial class EmployeeController : ControllerBase
{
      private readonly ILogger<EmployeeController> _logger;
      public IEmployeeServices _services { get; }

      public EmployeeController(ILogger<EmployeeController> logger, IEmployeeServices services)
      {
            _logger = logger;
            _services = services;
      }

}
