using Maksby.Contract.Client;
using Maksby.Services.IncomeServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ClientController : ControllerBase
{

      [HttpPut("{id:Guid}")]
      public async Task<ActionResult<Guid>> EditClient([FromRoute] Guid id, [FromBody] ClientRequest ClientRequest, CancellationToken cancellationToken)
      {
            return await _services.EditClient(id, ClientRequest, cancellationToken);
      }


}
