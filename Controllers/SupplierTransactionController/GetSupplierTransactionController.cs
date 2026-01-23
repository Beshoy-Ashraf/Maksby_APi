using Maksby.Contract.SupplierTransactions;
using Microsoft.AspNetCore.Mvc;



public partial class SupplierTransactionController : ControllerBase
{

      [HttpGet("{id:Guid}")]
      public async Task<ActionResult<GetSupplierTransactionRequest>> GetTransaction([FromRoute] Guid id, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetTransaction(id, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't get Transaction");
            }
      }
      [HttpGet]
      public async Task<ActionResult<List<GetSupplierTransactionRequest>>> GetSuppliersTransactions(CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetSuppliersTransactions(cancellationToken);
            }
            catch (Exception e)
            {
                  return BadRequest($"Can't get Transactions{e}");
            }
      }
      [HttpGet("invoice/{id:guid}")]
      public async Task<ActionResult<List<GetSupplierTransactionRequest>>> GetInvoicesTransactions([FromRoute] Guid id, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetInvoiceTransactions(id, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't get Invoice Transactions");
            }
      }


}
