namespace Maksby.Data.Models.Debt;

public class SupplierTransaction
{
      public int Id { get; set; }
      public int ClientId { get; set; }
      public DateTime Date { get; set; }

      public double Amount { get; set; }
}
