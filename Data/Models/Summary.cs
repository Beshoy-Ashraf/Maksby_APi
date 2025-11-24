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
      public double Salaries { get; set; }
      public double Expenses { get; set; }
      public double Revenue { get; set; }

}
