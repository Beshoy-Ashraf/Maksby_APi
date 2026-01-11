namespace Maksby.Data.Models;

public class Expense
{
      public Guid Id { get; set; }
      public string Description { get; set; } = "";
      public DateTime Date { get; set; } = DateTime.UtcNow;
      public double Amount { get; set; }
      public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
      public DateTime UpdatedDate { get; set; }
      public DateTime DeletedDate { get; set; }

      public required Summary Summary { get; set; }
}
