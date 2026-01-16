namespace Maksby.Contract.Batch;

public class AddItemsToBachRequest
{
      public Guid BatchId { get; set; }
      public List<AddBatchItems> AddBatchItems { get; set; } = [];

}
