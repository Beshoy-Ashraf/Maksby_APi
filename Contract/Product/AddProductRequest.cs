namespace Maksby.Contract.Product;

public class AddProductRequest
{

      public required string Name { get; set; }
      public required double QuantityPerKilo { get; set; }
      public double PricePerKilo { get; set; }
      public string Description { get; set; } = "";

}
