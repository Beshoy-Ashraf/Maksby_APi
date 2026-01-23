namespace Maksby.Contract.Transaction;

public class AddClientTransactionRequest
{
      public Guid ClientId { get; set; }
      public Guid InvoiceId { get; set; }
      public double Amount { get; set; }
}
