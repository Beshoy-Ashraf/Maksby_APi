using Maksby.Services.ItemServices.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/Item")]
[ApiController]
public partial class ItemController : ControllerBase
{
      private readonly ILogger<ItemController> _logger;
      public IItemService _services { get; }

      public ItemController(ILogger<ItemController> logger, IItemService services)
      {
            _logger = logger;
            _services = services;
      }



}
