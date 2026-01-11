namespace Maksby.Data.Models.User;

public class User
{
      public Guid Id { get; set; }
      public string Email { get; set; } = "";
      public required string Password { get; set; }
      public string FirstName { get; set; } = "";
      public string LastName { get; set; } = "";
      public string Phone { get; set; } = "";
      public string Role { get; set; } = "";
      public DateTime JoinedDate { get; set; } = DateTime.UtcNow;
      public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
      public DateTime UpdatedDate { get; set; }
      public DateTime DeletedDate { get; set; }

}
