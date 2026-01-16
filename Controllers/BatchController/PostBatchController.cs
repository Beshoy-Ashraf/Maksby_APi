
using Maksby.Contract.Batch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class BatchController : ControllerBase
{

      [HttpPost]
      public async Task<ActionResult<Guid>> AddBatch([FromBody] AddBatchRequest addBatchRequest, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.AddBatch(addBatchRequest, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't Add Batch");
            }
      }



}
