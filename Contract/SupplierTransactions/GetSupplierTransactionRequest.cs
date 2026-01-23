namespace Maksby.Contract.SupplierTransactions;

public class GetSupplierTransactionRequest
{
      public Guid Id { get; set; }
      public Guid SupplierId { get; set; }
      public Guid InvoiceId { get; set; }
      public double Amount { get; set; }
      public double OpenAmount { get; set; }
      public DateTime Date { get; set; }
}
