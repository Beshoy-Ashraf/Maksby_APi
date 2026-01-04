namespace Maksby.Data.Models.Income;

public class ClientInvoiceProduct
{
      public int Id { get; set; }
      public int ProductId { get; set; }
      public int ClientInvoiceId { get; set; }
      public double Amount { get; set; }
      public double PricePerKilo { get; set; }
      public double Quantity { get; set; }

      public double TotalAmount => Quantity * PricePerKilo;

      public Product? Product { get; private set; }
      public ClientInvoice? ClientInvoice { get; private set; }


}
