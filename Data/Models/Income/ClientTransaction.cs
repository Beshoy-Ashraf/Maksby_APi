namespace Maksby.Data.Models.Income;

public class ClientTransaction
{
      public int Id { get; set; }
      public int ClientId { get; set; }
      public DateTime Date { get; set; }

      public double Amount { get; set; }
}
