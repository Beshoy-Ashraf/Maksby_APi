namespace Maksby.Data.Modules;

public class Expenses
{
      public int Id { get; set; }

      public int Summary_Id { get; set; }

      public string? Description { get; set; }

      public DateTime Date { get; set; }

      public double Amount { get; set; }

      public DateTime Created_Date { get; set; }
      public DateTime Updated_Date { get; set; }
      public DateTime Deleted_Date { get; set; }


}
