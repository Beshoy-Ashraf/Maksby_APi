
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
                  var result = await _services.AddBatch(addBatchRequest, cancellationToken);
                  return Ok(result);
            }
            catch (Exception)
            {
                  return BadRequest("Can't Add Batch");
            }
      }
      [HttpPost("{id:guid}/add-item")]
      public async Task<ActionResult<Guid>> AddIBatch(Guid id, [FromBody] AddItemsToBachRequest addItemsToBatchRequest, CancellationToken cancellationToken)
      {
            try
            {
                  var result = await _services.AddItemsToBatch(id, addItemsToBatchRequest, cancellationToken);
                  return Ok(result);
            }
            catch (Exception e)
            {
                  return BadRequest($"Can't Add Items{e}");
            }
      }



}
