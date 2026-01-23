using Maksby.Services.ClientTransactionServices.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/client-transaction")]
[ApiController]
public partial class ClientTransactionController : ControllerBase
{
      private readonly ILogger<ClientTransactionController> _logger;
      public IClientTransactionServices _services { get; }

      public ClientTransactionController(ILogger<ClientTransactionController> logger, IClientTransactionServices services)
      {
            _logger = logger;
            _services = services;
      }



}
