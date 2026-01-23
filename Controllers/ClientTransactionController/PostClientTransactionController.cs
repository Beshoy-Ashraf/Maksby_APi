
using Maksby.Contract.Transaction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ClientTransactionController : ControllerBase
{

      [HttpPost]
      public async Task<ActionResult<Guid>> AddClientTransaction([FromBody] AddClientTransactionRequest addClientTransactionRequest, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.AddClientTransaction(addClientTransactionRequest, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't Add Transaction");
            }
      }


}
