
using Maksby.Contract.Transaction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ClientTransactionController : ControllerBase
{

      [HttpDelete("{id:Guid}")]
      public async Task<ActionResult> RefundClientTransaction([FromRoute] Guid id, CancellationToken cancellationToken)
      {
            try
            {
                  await _services.RefundClientTransaction(id, cancellationToken);
                  return Ok();
            }
            catch (Exception)
            {
                  return BadRequest("Can't refund Transaction");
            }

      }


}
