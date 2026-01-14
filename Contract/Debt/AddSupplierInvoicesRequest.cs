namespace Maksby.Contract.Debt;

public class AddSupplierInvoicesRequest
{
      public Guid Id { get; set; }
      public Guid SupplierId { get; set; }
      public DateTime InvoiceDate { get; set; }

      public List<SupplierInvoiceItem> supplierInvoiceItems { get; set; } = [];
}

public class SupplierInvoiceItem
{
      public Guid ItemId { get; set; }
      public double QuantityPerKilo { get; set; }
}
