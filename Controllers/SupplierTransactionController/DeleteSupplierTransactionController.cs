using Microsoft.AspNetCore.Mvc;



public partial class SupplierTransactionController : ControllerBase
{

      [HttpDelete("{id:Guid}")]
      public async Task<ActionResult> RefundSupplierTransaction([FromRoute] Guid id, CancellationToken cancellationToken)
      {
            try
            {
                  await _services.RefundSupplierTransaction(id, cancellationToken);
                  return Ok();
            }
            catch (Exception)
            {
                  return BadRequest("Can't refund Transaction");
            }

      }


}
