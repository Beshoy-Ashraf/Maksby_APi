using Maksby.Services.SummaryServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.SummaryController;

[Route("api/Summary")]
[ApiController]
public partial class SummaryController : ControllerBase
{
      private readonly ILogger<SummaryController> _logger;
      public ISummaryServices _services { get; }

      public SummaryController(ILogger<SummaryController> logger, ISummaryServices services)
      {
            _logger = logger;
            _services = services;
      }

}
