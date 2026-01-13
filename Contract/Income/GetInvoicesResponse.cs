using Maksby.Data.Models.Income;

namespace Maksby.Contract.Income;

public class GetInvoicesResponse
{
      public Guid InvoiceId { get; set; }
      public Guid ClientID { get; set; }
      public DateTime Date { get; set; }
      public Double Amount { get; set; }
      public Status Status { get; set; }
      public List<InvoiceItems> InvoiceItems { get; set; } = [];


}
public class InvoiceItems
{
      public Guid Id { get; set; }
      public Guid ProductId { get; set; }
      public String ProductName { get; set; } = "";
      public Double PricePerKilo { get; set; }
      public Double QuantityPerKilo { get; set; }
      public Double Amount => PricePerKilo * QuantityPerKilo;

}

public enum Status
{
      NotPaid,
      Pending,
      Completed,
}
