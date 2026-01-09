using Maksby.Data.Models.Debt;

namespace Maksby.Data.Models.batch;

public class BatchItem
{
      public Guid Id { get; set; }
      public double ItemQuantity { get; set; }

      public required Batch Batch { get; set; }

      public required Item Item { get; set; }

}
