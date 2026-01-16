using Maksby.Data.Models.Income;

namespace Maksby.Data.Models.batch;

public class Batch
{
      public Guid Id { get; set; }
      public required BatchStatus BatchStatus { get; set; }
      public ICollection<BatchItem> BatchItems { get; set; } = [];
      public double ProductQuantity { get; set; } = 0;
      public required Product Product { get; set; }
      public DateTime CreatedDate { get; set; }
      public DateTime UpdatedDate { get; set; }
      public DateTime DeletedDate { get; set; }


}
public enum BatchStatus
{
      closed,
      ruining,
      pending,
}
