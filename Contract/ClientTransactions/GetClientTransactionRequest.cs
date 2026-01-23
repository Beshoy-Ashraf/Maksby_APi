namespace Maksby.Contract.ClientTransactions;

public class GetClientTransactionRequest
{
      public Guid Id { get; set; }
      public Guid ClientId { get; set; }
      public Guid InvoiceId { get; set; }
      public double Amount { get; set; }
      public double OpenAmount { get; set; }
      public DateTime Date { get; set; }
}
