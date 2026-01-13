using Maksby.Contract.Expenses;

namespace Maksby.Services.ExpensesServices.Interface;

public interface IExpensesServices
{

      Task<Guid> AddExpense(AddExpenseRequest ExpenseRequest, CancellationToken cancellationToken);
      Task<Guid> EditExpense(Guid id, AddExpenseRequest ExpenseRequest, CancellationToken cancellationToken);
      Task<GetExpenseRequest> GetExpense(Guid id, CancellationToken cancellationToken);
      Task<List<GetExpenseRequest>> GetExpenses(CancellationToken cancellationToken);
}
