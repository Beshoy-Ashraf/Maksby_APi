namespace Maksby.Contract.Batch;

public class AddItemsToBachRequest
{
      public Guid BatchId { get; set; }
      public List<BatchItems> BatchItems { get; set; } = [];

}
