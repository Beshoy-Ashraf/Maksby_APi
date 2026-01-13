
using Maksby.Services.ExpensesServices.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/expense")]
[ApiController]
public partial class ExpenseController : ControllerBase
{
      private readonly ILogger<ExpenseController> _logger;
      public IExpensesServices _services { get; }

      public ExpenseController(ILogger<ExpenseController> logger, IExpensesServices services)
      {
            _logger = logger;
            _services = services;
      }



}
