namespace Maksby.Contract.Supplier;

public class GetSupplierRequest
{
      public Guid Id { get; set; }
      public string FirstName { get; set; } = "";
      public string LastName { get; set; } = "";

}
