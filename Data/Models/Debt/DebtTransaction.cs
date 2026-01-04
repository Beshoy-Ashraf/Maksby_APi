namespace Maksby.Data.Models.Debt;

public class DebtTransaction
{
      public int Id { get; set; }
      public int SupplierId { get; set; }
      public int DebtInvoiceId { get; set; }
      public double Amount { get; set; }
      public DateTime Date { get; set; }

      public Supplier? Supplier { get; private set; }

}
