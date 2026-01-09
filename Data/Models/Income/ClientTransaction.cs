namespace Maksby.Data.Models.Income;

public class ClientTransaction
{
      public Guid Id { get; set; }
      public DateTime Date { get; set; } = DateTime.Now;

      public double Amount { get; set; }

      public required ClientInvoice ClientInvoice { get; set; }

      public required Client Client { get; set; }
}
