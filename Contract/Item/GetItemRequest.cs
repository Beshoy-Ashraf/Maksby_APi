namespace Maksby.Contract.Item;

public class GetItemRequest
{
      public Guid Id { get; set; }
      public string Name { get; set; } = "";
      public string Description { get; set; } = "";

      public double QuantityPerKilo { get; set; }
      public double PricePerKilo { get; set; }

}
