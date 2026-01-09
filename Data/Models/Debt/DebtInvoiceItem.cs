using Maksby.Data.Models.Income;

namespace Maksby.Data.Models.Debt;

public class DebtInvoiceItem
{
      public Guid Id { get; set; }
      public double PricePerKilo { get; set; }
      public double Quantity { get; set; }
      public double Amount => Quantity * PricePerKilo;
      public required DebtInvoice DebtInvoice { get; set; }
      public required Item Items { get; set; }



}
