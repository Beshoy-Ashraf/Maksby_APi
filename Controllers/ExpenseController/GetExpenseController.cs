using Maksby.Contract.Expenses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ExpenseController : ControllerBase
{

      [HttpGet("{id:Guid}")]
      public async Task<ActionResult<GetExpenseRequest>> GetExpense([FromRoute] Guid id, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetExpense(id, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't get Expense");
            }
      }
      [HttpGet]
      public async Task<ActionResult<List<GetExpenseRequest>>> GetExpenses(CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetExpenses(cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't get Expenses");
            }
      }


}
