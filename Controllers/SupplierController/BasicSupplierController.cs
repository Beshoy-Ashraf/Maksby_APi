using Maksby.Services.DebtServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.SupplierController;

[Route("api/supplier")]
[ApiController]
public partial class SupplierController : ControllerBase
{
      private readonly ILogger<SupplierController> _logger;
      public ISupplierService _services { get; }

      public SupplierController(ILogger<SupplierController> logger, ISupplierService services)
      {
            _logger = logger;
            _services = services;
      }

}
