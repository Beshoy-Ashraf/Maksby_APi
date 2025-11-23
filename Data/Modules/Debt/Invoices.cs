namespace Maksby.Data.Modules.Debt;

public class Invoices
{
      public int Id { get; set; }

      public int Summary_Id { get; set; }

      public int Supplier_Id { get; set; }

      public DateTime Date { get; set; }
      public double Amount { get; set; }

}
