using Maksby.Data.Models.Debt;

namespace Maksby.Data.Models.batch;

public class BatchItem
{
      public int Id { get; set; }
      public int BatchId { get; set; }
      public int ItemId { get; set; }
      public double ItemQuantity { get; set; }

      public Batch? Batch { get; private set; }

      public Item? Item { get; private set; }

}
