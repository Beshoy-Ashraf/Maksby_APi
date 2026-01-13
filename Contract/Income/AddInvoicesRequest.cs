using Maksby.Data.Models.Income;

namespace Maksby.Contract;

public class AddInvoiceRequest
{
      public Guid ClientId { get; set; }

      public required List<ClientInvoiceProductItem> ClientInvoiceProductItem { get; set; } = new List<ClientInvoiceProductItem>();
}

public class ClientInvoiceProductItem
{
      public Guid ProductId { get; set; }
      public double QuantityPerKilo { get; set; }
}
