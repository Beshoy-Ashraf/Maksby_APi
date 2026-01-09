namespace Maksby.Data.Models.Income;

public class ClientInvoice
{
      public Guid Id { get; set; }

      public DateTime Date { get; set; } = DateTime.Now;

      public double Amount { get; set; }
      public Status Status { get; set; } = Status.NotPaid;

      public ICollection<ClientInvoiceProduct> ClientInvoiceProducts { get; set; } = [];

      public ICollection<ClientTransaction> ClientTransactions { get; set; } = [];

      public required Summary Summary { get; set; }

      public required Client Client { get; set; }
}

public enum Status
{
      NotPaid,
      pending,
      Completed,
}