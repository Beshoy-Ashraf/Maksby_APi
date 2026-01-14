using Maksby.Data.Models.Income;

namespace Maksby.Data.Models.Debt;

public class DebtInvoiceItem
{
      public Guid Id { get; set; }
      public double PricePerKilo { get; set; }
      public double QuantityPerKilo { get; set; }
      public double Amount { get; set; }
      public required DebtInvoice DebtInvoice { get; set; }
      public required Item Item { get; set; }



}
