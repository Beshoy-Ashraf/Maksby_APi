using Maksby.Contract.Client;
using Maksby.Services.IncomeServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ClientController : ControllerBase
{

      [HttpGet("{id:Guid}")]
      public async Task<ActionResult<ClientRequest>> GetClient([FromRoute] Guid id, CancellationToken cancellationToken)
      {
            return await _services.GetClient(id, cancellationToken);
      }
      [HttpGet]
      public async Task<ActionResult<List<ClientRequest>>> GetClients(CancellationToken cancellationToken)
      {
            return await _services.GetClients(cancellationToken);
      }


}
