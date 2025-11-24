namespace Maksby.Data.Models.Income;

public class Client
{
      public int Id { get; set; }
      public required string Name { get; set; }
      public double balance { get; set; }
      public DateTime CreatedDate { get; set; }
      public DateTime UpdatedDate { get; set; }
      public DateTime DeletedDate { get; set; }
}
