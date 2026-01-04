namespace Maksby.Data.Models.Income;

public class ClientInvoice
{
      public int Id { get; set; }
      public int SummrayId { get; set; }
      public int ClientId { get; set; }
      public DateTime Date { get; set; }

      public double Amount { get; set; }
      public required string Status { get; set; }

      public ICollection<ClientInvoiceProduct>? ClientInvoiceProducts { get; set; }

      public ICollection<ClientTransaction>? ClientTransactions { get; set; }

      public Summary? Summary { get; private set; }

      public Client? Client { get; private set; }
}
