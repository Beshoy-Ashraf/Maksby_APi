namespace Maksby.Data.Models.Debt;

public class DebtInvoice
{
      public Guid Id { get; set; }

      public DateTime Date { get; set; } = DateTime.UtcNow;
      public double Amount { get; set; }
      public required Supplier Supplier { get; set; }
      public required Summary Summary { get; set; }
      public ICollection<DebtInvoiceItem> DebtInvoiceItems { get; set; } = [];
      public ICollection<DebtTransaction> DebtTransactions { get; set; } = [];

}
