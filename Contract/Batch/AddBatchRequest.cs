using Maksby.Data.Models.batch;

namespace Maksby.Contract.Batch;

public class AddBatchRequest
{
      public required List<AddBatchItems> AddBatchItems { get; set; }
      public Guid ProductId { get; set; }
      public double ProductQuantity { get; set; } = 0;
      public BatchStatus BatchStatus { get; set; } = BatchStatus.ruining;

}
public class AddBatchItems
{
      public Guid ItemId { get; set; }
      public double ItemQuantity { get; set; }
      public required DateTime ModifyDate { get; set; }
}


