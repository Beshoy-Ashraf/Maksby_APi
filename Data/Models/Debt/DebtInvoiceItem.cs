using Maksby.Data.Models.Income;

namespace Maksby.Data.Models.Debt;

public class DebtInvoiceItem
{
      public int Id { get; set; }

      public int InvoicesId { get; set; }
      public int ItemId { get; set; }
      public double PricePerKilo { get; set; }
      public double Quantity { get; set; }
      public double Amount => Quantity * PricePerKilo;

      public DebtInvoice? DebtInvoice { get; private set; }

      public Item? Items { get; set; }



}
