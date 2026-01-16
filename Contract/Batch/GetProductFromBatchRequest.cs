namespace Maksby.Contract.Batch;

public class GetProductFromBatchRequest
{
      public Guid BatchId { get; set; }
      public required Guid ProductId { get; set; }
      public required double ProductQuantity { get; set; }
}
