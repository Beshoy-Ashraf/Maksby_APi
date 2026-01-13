using Maksby.Data.Models.batch;

namespace Maksby.Data.Models.Debt;

public class Item
{
      public Guid Id { get; set; }
      public string Name { get; set; } = "";
      public string Description { get; set; } = "";
      public double QuantityPerKilo { get; set; }
      public double PricePerKilo { get; set; }
      public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
      public DateTime UpdatedDate { get; set; }
      public DateTime DeletedDate { get; set; }

      public ICollection<DebtInvoiceItem> DebtInvoiceItem { get; set; } = [];
      public ICollection<BatchItem> BatchItems { get; set; } = [];

}
