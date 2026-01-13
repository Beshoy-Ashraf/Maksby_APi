namespace Maksby.Contract.Expenses;

public class GetExpenseRequest
{
      public Guid Id { get; set; }
      public string Description { get; set; } = "";
      public DateTime Date { get; set; } = DateTime.UtcNow;
      public double Amount { get; set; }

}
