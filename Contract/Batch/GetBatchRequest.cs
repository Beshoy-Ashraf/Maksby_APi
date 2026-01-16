
using Maksby.Data.Models.batch;

namespace Maksby.Contract.Batch;

public class GetBatchRequest
{
      public Guid Id { get; set; }
      public List<BatchItems> BatchItems { get; set; } = [];
      public Guid ProductId { get; set; }
      public required string ProductName { get; set; }
      public double ProductQuantity { get; set; }
      public BatchStatus BatchStatus { get; set; }

}

public class BatchItems
{
      public Guid ItemId { get; set; }
      public double ItemQuantity { get; set; }
      public required string ItemName { get; set; }
      public required DateTime ModifyDate { get; set; }
}
