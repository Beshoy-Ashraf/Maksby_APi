
using Maksby.Contract.Expenses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ExpenseController : ControllerBase
{

      [HttpPut("{id:Guid}")]
      public async Task<ActionResult<Guid>> EditExpense([FromRoute] Guid id, [FromBody] AddExpenseRequest addExpenseRequest, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.EditExpense(id, addExpenseRequest, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't Edit Expense");
            }

      }


}
