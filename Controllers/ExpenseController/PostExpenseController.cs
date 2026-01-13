
using Maksby.Contract.Expenses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ExpenseController : ControllerBase
{

      [HttpPost]
      public async Task<ActionResult<Guid>> AddExpense([FromBody] AddExpenseRequest addExpenseRequest, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.AddExpense(addExpenseRequest, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't Add Expense");
            }
      }


}
