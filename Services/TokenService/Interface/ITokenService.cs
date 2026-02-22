using Maksby.Contract.Token;

namespace Maksby.Services.TokenService.Interface;

public interface ITokenService
{
      Task<string> AuthenticateUser(AuthenticationRequest Request, CancellationToken cancellationToken);
}
