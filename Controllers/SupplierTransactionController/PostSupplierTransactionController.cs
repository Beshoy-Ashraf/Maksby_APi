
using Maksby.Contract.SupplierTransactions;
using Microsoft.AspNetCore.Mvc;



public partial class SupplierTransactionController : ControllerBase
{

      [HttpPost]
      public async Task<ActionResult<Guid>> AddSupplierTransaction([FromBody] AddSupplierTransactionRequest addSupplierTransactionRequest, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.AddSupplierTransaction(addSupplierTransactionRequest, cancellationToken);
            }
            catch (Exception e)
            {
                  return BadRequest($"Can't Add Transaction{e}");
            }
      }


}
