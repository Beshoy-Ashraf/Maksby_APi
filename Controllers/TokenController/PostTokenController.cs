
using Maksby.Contract.Token;
using Microsoft.AspNetCore.Mvc;


public partial class TokenController : ControllerBase
{
      [HttpPost]
      public async Task<ActionResult<string>> AuthenticateUser([FromBody] AuthenticationRequest Request, CancellationToken cancellationToken)
      {
            try
            {

                  return await _services.AuthenticateUser(Request, cancellationToken);
            }
            catch (Exception e)
            {
                  return BadRequest($"Can't create token {e.Message}");
            }
      }
}
