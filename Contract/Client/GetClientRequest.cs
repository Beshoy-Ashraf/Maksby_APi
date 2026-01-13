using System.Security.Cryptography.X509Certificates;

namespace Maksby.Contract.Client;

public class GetClientRequest
{
      public Guid Id { get; set; }
      public required string Name { get; set; }
      public double Balance { get; set; }
}
