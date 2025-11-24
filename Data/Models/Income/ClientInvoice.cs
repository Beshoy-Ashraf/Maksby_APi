namespace Maksby.Data.Models.Income;

public class ClientInvoice
{
      public int Id { get; set; }
      public int SummrayId { get; set; }
      public int ClientId { get; set; }
      public DateTime Date { get; set; }

      public double Amount { get; set; }
      public required string Status { get; set; }
}
