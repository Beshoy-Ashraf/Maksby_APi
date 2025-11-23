namespace Maksby.Data.Modules.User;

public class User
{
      public int Id { get; set; }
      public string? Email { get; set; }
      public required string Password { get; set; }
      public string? First_Name { get; set; }
      public string? Last_Name { get; set; }
      public string? Phone { get; set; }
      public string? Role { get; set; }
      public DateTime Joined_Date { get; set; }
      public DateTime Created_Date { get; set; }
      public DateTime Updated_Date { get; set; }
      public DateTime Deleted_Date { get; set; }


}
