
using Maksby.Contract.Batch;
using Maksby.Data.Models.batch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class BatchController : ControllerBase
{

      [HttpPut("{id:Guid}")]
      public async Task<ActionResult<Guid>> EditBatch([FromRoute] Guid id, [FromBody] AddBatchRequest addBatchRequest, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.EditBatch(id, addBatchRequest, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't Edit Batch");
            }

      }
      [HttpPut("{id:Guid}/change-status")]
      public async Task<ActionResult<Guid>> ChangeStatus([FromRoute] Guid id, [FromHeader] BatchStatus status, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.ChangeBatchStatus(id, status, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't Change Batch Status");
            }

      }


}
