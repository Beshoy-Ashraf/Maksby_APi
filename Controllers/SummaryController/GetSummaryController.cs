using Maksby.Contract.Summary;
using Maksby.Services.SummaryServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.SummaryController;


public partial class SummaryController : ControllerBase
{
      [HttpGet]
      public async Task<ActionResult<GetSummaryRequest>> GetSummary(CancellationToken cancellationToken)
      {
            var response = await _services.GetSummary(cancellationToken);
            return Ok(response);
      }
}
