using Maksby.Data.Models.Income;

namespace Maksby.Data.Models.batch;

public class Batch
{
      public Guid Id { get; set; }
      public DateTime Date { get; set; } = DateTime.UtcNow;
      public required string Status { get; set; }
      public ICollection<BatchItem> BatchItems { get; set; } = [];
      public required Product Product { get; set; }


}
