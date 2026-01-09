namespace Maksby.Data.Models.Employee;

public class Employee
{
      public Guid Id { get; set; }


      public string FirstName { get; set; } = "";
      public string LastName { get; set; } = "";
      public DateTime CreatedDate { get; set; } = DateTime.Now;
      public DateTime UpdatedDate { get; set; }
      public DateTime DeletedDate { get; set; }

      public ICollection<Salary> Salaries { get; set; } = [];
}

