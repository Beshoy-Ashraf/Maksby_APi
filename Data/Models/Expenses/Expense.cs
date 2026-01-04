namespace Maksby.Data.Models;

public class Expense
{
      public int Id { get; set; }

      public int SummaryId { get; set; }

      public string? Description { get; set; }

      public DateTime Date { get; set; }

      public double Amount { get; set; }

      public DateTime CreatedDate { get; set; }
      public DateTime UpdatedDate { get; set; }
      public DateTime DeletedDate { get; set; }

      public Summary? Summary { get; private set; }
}
