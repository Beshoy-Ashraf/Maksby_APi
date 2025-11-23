namespace Maksby.Data.Modules.Debt;

public class InvoicesItem
{
      public int Id { get; set; }

      public int Invoices_Id { get; set; }
      public int Item_Id { get; set; }
      public double Price_Per_Kilo { get; set; }
      public double Quantity { get; set; }
      public double Amount => Quantity * Price_Per_Kilo;

}
