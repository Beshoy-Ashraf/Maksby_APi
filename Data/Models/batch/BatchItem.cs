using Maksby.Data.Models.Debt;

namespace Maksby.Data.Models.batch;

public class BatchItem
{
      public Guid Id { get; set; }
      public double ItemQuantityPerKilo { get; set; }
      public DateTime ModifyDate { get; set; }

      public required Batch Batch { get; set; }

      public required Item Item { get; set; }

}
