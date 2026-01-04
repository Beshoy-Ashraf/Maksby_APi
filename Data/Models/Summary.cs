using Maksby.Data.Models.Debt;
using Maksby.Data.Models.Employee;
using Maksby.Data.Models.Income;

namespace Maksby.Data.Models;

public class Summary
{
      public int Id { get; set; }
      public int UserId { get; set; }
      public DateTime Date { get; set; }
      public double InitialValue { get; set; }
      public double ActualIncome { get; set; }
      public double EtimatedIncome { get; set; }
      public double ActualDebt { get; set; }
      public double EtimatedDebt { get; set; }
      public double TotalSalaries { get; set; }
      public double TotalExpenses { get; set; }
      public double Revenue { get; set; }

      public ICollection<Salary>? Salaries { get; set; }
      public ICollection<Expense>? Expenses { get; set; }
      public ICollection<DebtInvoice>? DebtInvoices { get; set; }
      public ICollection<ClientInvoice>? ClientInvoices { get; set; }

      public User.User? User { get; set; }
}

