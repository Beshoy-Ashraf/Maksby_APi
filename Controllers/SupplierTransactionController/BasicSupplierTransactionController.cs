using Maksby.Services.SupplierTransactionServices.Interface;
using Microsoft.AspNetCore.Mvc;


[Route("api/supplier-transaction")]
[ApiController]
public partial class SupplierTransactionController : ControllerBase
{
      private readonly ILogger<SupplierTransactionController> _logger;
      public ISupplierTransactionServices _services { get; }

      public SupplierTransactionController(ILogger<SupplierTransactionController> logger, ISupplierTransactionServices services)
      {
            _logger = logger;
            _services = services;
      }



}
