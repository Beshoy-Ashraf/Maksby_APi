namespace Maksby.Contract.Summary
{
      public class GetSummaryRequest
      {
            public Guid Id { get; set; }
            public DateTime Date { get; set; }
            public double InitialValue { get; set; }
            public double ActualIncome { get; set; }
            public double EstimatedIncome { get; set; }
            public double ActualDebt { get; set; }
            public double EstimatedDebt { get; set; }
            public double TotalSalaries { get; set; }
            public double TotalExpenses { get; set; }
            public double Revenue { get; set; }
      }
}