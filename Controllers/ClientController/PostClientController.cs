using Maksby.Contract.Client;
using Maksby.Services.IncomeServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ClientController : ControllerBase
{

      [HttpPost]
      public async Task<ActionResult<Guid>> AddClient([FromBody] AddClientRequest addClientRequest, CancellationToken cancellationToken)
      {

            try
            {
                  return await _services.AddClient(addClientRequest, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't Add Client");
            }

      }


}
