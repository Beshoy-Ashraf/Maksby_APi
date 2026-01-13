using Maksby.Services.ProductServices.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/product")]
[ApiController]
public partial class ProductController : ControllerBase
{
      private readonly ILogger<ProductController> _logger;
      public IProductService _services { get; }

      public ProductController(ILogger<ProductController> logger, IProductService services)
      {
            _logger = logger;
            _services = services;
      }



}
