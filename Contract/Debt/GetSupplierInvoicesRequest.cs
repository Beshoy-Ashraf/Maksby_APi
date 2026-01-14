
namespace Maksby.Contract.Debt;

public class GetSupplierInvoicesRequest
{
      public Guid InvoiceId { get; set; }
      public Guid SupplierId { get; set; }
      public DateTime InvoiceDate { get; set; }
      public double TotalInvoiceAmount { get; set; }
      public Status Status { get; set; }
      public List<ItemDetails> ItemDetails { get; set; } = [];


}
public class ItemDetails
{
      public Guid Id { get; set; }
      public Guid ItemId { get; set; }
      public required string ItemName { get; set; }
      public double PricePerKilo { get; set; }
      public double QuantityPerKilo { get; set; }
      public double Amount { get; set; }
}
public enum Status
{
      NotPaid,
      Pending,
      Completed,
}
