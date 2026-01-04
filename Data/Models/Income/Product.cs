using Maksby.Data.Models.batch;

namespace Maksby.Data.Models.Income;

public class Product
{
      public int Id { get; set; }
      public required string Name { get; set; }
      public string? Description { get; set; }
      public DateTime CreatedDate { get; set; }
      public DateTime UpdatedDate { get; set; }
      public DateTime DeletedDate { get; set; }
      public ICollection<Batch>? Batches { get; set; }
      public ICollection<ClientInvoiceProduct>? ClientInvoiceProducts { get; set; }


}
