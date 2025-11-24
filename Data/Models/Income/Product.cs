namespace Maksby.Data.Models.Income;

public class Product
{
      public int ID { get; set; }
      public required string Name { get; set; }
      public string? Description { get; set; }
      public DateTime CreatedDate { get; set; }
      public DateTime UpdatedDate { get; set; }
      public DateTime DeletedDate { get; set; }



}
