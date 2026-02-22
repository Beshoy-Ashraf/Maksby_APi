using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Maksby.Contract.Token;
using Maksby.Data.Context;
using Maksby.Services.TokenService.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Maksby.Services.TokenService;

public class TokenService : ITokenService
{
      private readonly AppDBContext _dbContext;
      private readonly IServiceProvider _serviceProvider;
      private readonly ILogger<TokenService> _logger;
      private readonly JwtOptions _JwtOption;

      public TokenService(AppDBContext dbContext, IServiceProvider serviceProvider, ILogger<TokenService> logger, JwtOptions jwtOptions)
      {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            _logger = logger;
            _JwtOption = jwtOptions;
      }

      public async Task<string> AuthenticateUser(AuthenticationRequest Request, CancellationToken cancellationToken)
      {
            var userData = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == Request.Email, cancellationToken)
                ?? throw new KeyNotFoundException($"User with email {Request.Email} was not found.");

            if (userData.Password != Request.Password)
            {
                  throw new UnauthorizedAccessException("Invalid password.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                  Issuer = _JwtOption.Issuer,
                  Audience = _JwtOption.Audience,
                  SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JwtOption.SigningKey)),
                        SecurityAlgorithms.HmacSha256),
                  Subject = new ClaimsIdentity(new Claim[]
                  {
                        new(ClaimTypes.NameIdentifier, Request.Email),
                  })
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);
            return accessToken;
      }


}
