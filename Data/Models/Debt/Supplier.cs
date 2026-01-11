namespace Maksby.Data.Models.Debt;

public class Supplier
{
      public Guid Id { get; set; }
      public string FirstName { get; set; } = "";
      public string LastName { get; set; } = "";

      public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
      public DateTime UpdatedDate { get; set; }
      public DateTime DeletedDate { get; set; }


      public ICollection<DebtTransaction> DebtTransactions { get; set; } = [];
      public ICollection<DebtInvoice> DebtInvoices { get; set; } = [];
}
