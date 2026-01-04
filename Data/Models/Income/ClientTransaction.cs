namespace Maksby.Data.Models.Income;

public class ClientTransaction
{
      public int Id { get; set; }
      public int ClientId { get; set; }
      public int ClientInvoiceId { get; set; }

      public DateTime Date { get; set; }

      public double Amount { get; set; }

      public ClientInvoice? ClientInvoice { get; private set; }

      public Client? Client { get; private set; }
}
