


using Maksby.Contract.Expenses;
using Maksby.Data.Context;
using Maksby.Data.Models;
using Maksby.Services.ExpensesServices.Interface;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Services.ExpensesServices;

public class ExpensesServices : IExpensesServices
{
      private readonly AppDBContext _dbContext;
      private readonly IServiceProvider _serviceProvider;
      private readonly ILogger<ExpensesServices> _logger;

      public ExpensesServices(AppDBContext dbContext, IServiceProvider serviceProvider, ILogger<ExpensesServices> logger)
      {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            _logger = logger;
      }
      public async Task<Guid> AddExpense(AddExpenseRequest addExpenseRequest, CancellationToken cancellationToken)
      {
            var Summary = await _dbContext.Summaries.FirstAsync(cancellationToken);
            Summary.TotalExpenses += addExpenseRequest.Amount;
            var Expense = new Expense
            {
                  Description = addExpenseRequest.Description,
                  Amount = addExpenseRequest.Amount,
                  Date = DateTime.UtcNow,
                  UpdatedDate = DateTime.UtcNow,
                  DeletedDate = DateTime.UtcNow,
                  Summary = Summary

            };

            await _dbContext.Expenses.AddAsync(Expense, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Expense.Id;

      }
      public async Task<Guid> EditExpense(Guid id, AddExpenseRequest addExpenseRequest, CancellationToken cancellationToken)
      {
            var Expense = await _dbContext.Expenses.FirstOrDefaultAsync(c => c.Id == id, cancellationToken) ?? throw new Exception("Expense not found");
            var Summary = await _dbContext.Summaries.FirstAsync(cancellationToken);
            Summary.TotalExpenses -= Expense.Amount;
            Summary.TotalExpenses += addExpenseRequest.Amount;

            Expense.Description = addExpenseRequest.Description;
            Expense.Amount = addExpenseRequest.Amount;
            Expense.UpdatedDate = DateTime.UtcNow;

            _dbContext.Expenses.Update(Expense);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Expense.Id;
      }
      public async Task<GetExpenseRequest> GetExpense(Guid id, CancellationToken cancellationToken)
      {
            var Expense = await _dbContext.Expenses.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (Expense == null)
            {
                  throw new Exception("Expense not found");
            }

            var retrieveExpense = new GetExpenseRequest
            {
                  Id = Expense.Id,
                  Description = Expense.Description,
                  Date = Expense.Date,
                  Amount = Expense.Amount
            };


            return retrieveExpense;
      }
      public async Task<List<GetExpenseRequest>> GetExpenses(CancellationToken cancellationToken)
      {
            var Expense = await _dbContext.Expenses.ToListAsync(cancellationToken);
            if (Expense == null)
            {
                  throw new Exception("Expense not found");
            }
            List<GetExpenseRequest> ExpenseList = new List<GetExpenseRequest>();
            foreach (var ele in Expense)
            {
                  var retrieveExpense = new GetExpenseRequest
                  {

                        Id = ele.Id,
                        Description = ele.Description,
                        Date = ele.Date,
                        Amount = ele.Amount
                  };
                  ExpenseList.Add(retrieveExpense);
            }
            return ExpenseList;
      }
}
