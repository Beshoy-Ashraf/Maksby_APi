namespace Maksby.Contract.Item;

public class AddItemRequest
{

      public string Name { get; set; } = "";
      public double QuantityPerKilo { get; set; }
      public double PricePerKilo { get; set; }
      public string Description { get; set; } = "";


}
