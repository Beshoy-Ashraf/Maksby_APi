using Maksby.Services.IncomeServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/client")]
[ApiController]
public partial class ClientController : ControllerBase
{
      private readonly ILogger<ClientController> _logger;
      public IClientService _services { get; }

      public ClientController(ILogger<ClientController> logger, IClientService services)
      {
            _logger = logger;
            _services = services;
      }



}
