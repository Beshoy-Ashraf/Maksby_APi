namespace Maksby.Data.Models.Income;

public class ClientInvoiceProduct
{
      public Guid Id { get; set; }

      public double PricePerKilo { get; set; }
      public double QuantityPerKilo { get; set; }

      public double TotalAmount => QuantityPerKilo * PricePerKilo;

      public required Product Product { get; set; }
      public required ClientInvoice ClientInvoice { get; set; }


}
