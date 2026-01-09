namespace Maksby.Data.Models.Debt;

public class DebtTransaction
{
      public Guid Id { get; set; }
      public double Amount { get; set; }
      public DateTime Date { get; set; } = DateTime.Now;

      public required Supplier Supplier { get; set; }
      public required DebtInvoice DebtInvoice { get; set; }

}
