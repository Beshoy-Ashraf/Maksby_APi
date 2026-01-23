namespace Maksby.Contract.SupplierTransactions;

public class AddSupplierTransactionRequest
{
      public Guid SupplierId { get; set; }
      public Guid InvoiceId { get; set; }
      public double Amount { get; set; }
}
