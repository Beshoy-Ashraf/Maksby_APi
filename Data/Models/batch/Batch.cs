namespace Maksby.Data.Models.batch;

public class Batch
{
      public int Id { get; set; }
      public int ProductId { get; set; }
      public DateTime Date { get; set; }
      public required string Status { get; set; }
}
