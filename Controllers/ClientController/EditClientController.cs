using Maksby.Contract.Client;
using Maksby.Services.ClientServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ClientController : ControllerBase
{

      [HttpPut("{id:Guid}")]
      public async Task<ActionResult<Guid>> EditClient([FromRoute] Guid id, [FromBody] AddClientRequest addClientRequest, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.EditClient(id, addClientRequest, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't edit client");
            }
      }


}
