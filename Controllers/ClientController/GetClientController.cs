using Maksby.Contract.Client;
using Maksby.Services.IncomeServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ClientController : ControllerBase
{

      [HttpGet("{id:Guid}")]
      public async Task<ActionResult<GetClientRequest>> GetClient([FromRoute] Guid id, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetClient(id, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't get Client");
            }
      }
      [HttpGet]
      public async Task<ActionResult<List<GetClientRequest>>> GetClients(CancellationToken cancellationToken)
      {

            try
            {
                  return await _services.GetClients(cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't get Clients");
            }
      }


}
