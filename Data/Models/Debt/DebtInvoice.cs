namespace Maksby.Data.Models.Debt;

public class DebtInvoice
{
      public Guid Id { get; set; }

      public DateTime Date { get; set; } = DateTime.UtcNow;
      public double Amount { get; set; }
      public Status Status { get; set; } = Status.NotPaid;
      public double OpenAmount { get; set; } = 0;
      public required Supplier Supplier { get; set; }
      public required Summary Summary { get; set; }
      public ICollection<DebtInvoiceItem> DebtInvoiceItems { get; set; } = [];
      public ICollection<DebtTransaction> DebtTransactions { get; set; } = [];

}
public enum Status
{
      NotPaid,
      Pending,
      Completed,
}
