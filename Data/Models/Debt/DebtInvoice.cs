namespace Maksby.Data.Models.Debt;

public class DebtInvoice
{
      public int Id { get; set; }

      public int SummaryId { get; set; }

      public int SupplierId { get; set; }

      public DateTime Date { get; set; }
      public double Amount { get; set; }


      public Supplier? Supplier { get; private set; }
      public Summary? Summary { get; private set; }

      public ICollection<DebtInvoiceItem>? DebtInvoiceItems { get; set; }

}
