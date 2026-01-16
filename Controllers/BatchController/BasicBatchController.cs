
using Maksby.Services.BatchServices.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/Batch")]
[ApiController]
public partial class BatchController : ControllerBase
{
      private readonly ILogger<BatchController> _logger;
      public IBatchServices _services { get; }

      public BatchController(ILogger<BatchController> logger, IBatchServices services)
      {
            _logger = logger;
            _services = services;
      }



}
