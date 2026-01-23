using Maksby.Contract.ClientTransactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ClientTransactionController : ControllerBase
{

      [HttpGet("{id:Guid}")]
      public async Task<ActionResult<GetClientTransactionRequest>> GetTransaction([FromRoute] Guid id, CancellationToken cancellationToken)
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
      public async Task<ActionResult<List<GetClientTransactionRequest>>> GetClientsTransactions(CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetClientsTransactions(cancellationToken);
            }
            catch (Exception e)
            {
                  return BadRequest($"Can't get Transactions{e}");
            }
      }
      [HttpGet("invoice/{id:guid}")]
      public async Task<ActionResult<List<GetClientTransactionRequest>>> GetInvoicesTransactions([FromRoute] Guid id, CancellationToken cancellationToken)
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
