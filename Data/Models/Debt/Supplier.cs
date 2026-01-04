namespace Maksby.Data.Models.Debt;

public class Supplier
{
      public int Id { get; set; }
      public string? FirstName { get; set; }
      public string? LastName { get; set; }

      public DateTime CreatedDate { get; set; }
      public DateTime UpdatedDate { get; set; }
      public DateTime DeletedDate { get; set; }


      public ICollection<DebtTransaction>? DebtTransactions { get; set; }
      public ICollection<DebtInvoice>? DebtInvoices { get; set; }
}
