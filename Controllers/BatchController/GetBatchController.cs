using Maksby.Contract.Batch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class BatchController : ControllerBase
{

      [HttpGet("{id:Guid}")]
      public async Task<ActionResult<GetBatchRequest>> GetBatch([FromRoute] Guid id, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetBatch(id, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't get Batch");
            }
      }
      [HttpGet]
      public async Task<ActionResult<List<GetBatchRequest>>> GetBatches(CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetBatches(cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't get Batches");
            }
      }


}
