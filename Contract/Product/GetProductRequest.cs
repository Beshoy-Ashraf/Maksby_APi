namespace Maksby.Contract.Product;

public class GetProductRequest
{
      public Guid Id { get; set; }
      public required string Name { get; set; }
      public required double QuantityPerKilo { get; set; }
      public double PricePerKilo { get; set; }
      public string Description { get; set; } = "";

}
