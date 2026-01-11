using Maksby.Contract.Client;
using Maksby.Services.IncomeServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ClientController : ControllerBase
{

      [HttpPost]
      public async Task<ActionResult<Guid>> AddClient([FromBody] ClientRequest ClientRequest, CancellationToken cancellationToken)
      {
            return await _services.AddClient(ClientRequest, cancellationToken);
      }


}
