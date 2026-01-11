using System.Security.Cryptography.X509Certificates;

namespace Maksby.Data.Models.Income;

public class Client
{
      public Guid Id { get; set; }
      public required string Name { get; set; }
      public double Balance { get; set; }
      public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
      public DateTime UpdatedDate { get; set; }
      public DateTime DeletedDate { get; set; }

      public ICollection<ClientInvoice> ClientInvoices { get; set; } = [];
      public ICollection<ClientTransaction>? ClientTransactions { get; set; } = [];

      public static implicit operator List<object>(Client v)
      {
            throw new NotImplementedException();
      }
}
