using Maksby.Services.TokenService.Interface;
using Microsoft.AspNetCore.Mvc;

[Route("api/create-token")]
[ApiController]
public partial class TokenController : ControllerBase
{
      private readonly ILogger<TokenController> _logger;
      public ITokenService _services { get; }

      public TokenController(ILogger<TokenController> logger, ITokenService services)
      {
            _logger = logger;
            _services = services;
      }
}
