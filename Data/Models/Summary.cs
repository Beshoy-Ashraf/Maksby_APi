using Maksby.Data.Models.Debt;
using Maksby.Data.Models.Employee;
using Maksby.Data.Models.Income;

namespace Maksby.Data.Models;

public class Summary
{
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public double InitialValue { get; set; }
      public double ActualIncome { get; set; }
      public double EstimatedIncome { get; set; }
      public double EstimatedDebt { get; set; }
      public double PaidForSuppliers { get; set; }
      public double ActualDebt => EstimatedDebt - PaidForSuppliers;

      public double TotalSalaries { get; set; }
      public double TotalExpenses { get; set; }
      public double Revenue => InitialValue + EstimatedIncome - ActualDebt - TotalExpenses - TotalSalaries;
      public double ActualMoney => InitialValue + ActualIncome - PaidForSuppliers - TotalExpenses - TotalSalaries;

      public ICollection<Salary> Salaries { get; set; } = [];
      public ICollection<Expense> Expenses { get; set; } = [];
      public ICollection<DebtInvoice> DebtInvoices { get; set; } = [];
      public ICollection<ClientInvoice> ClientInvoices { get; set; } = [];

}

