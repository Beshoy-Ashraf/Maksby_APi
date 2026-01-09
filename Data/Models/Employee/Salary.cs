namespace Maksby.Data.Models.Employee;

public class Salary
{
      public Guid Id { get; set; }
      public DateTime Date { get; set; } = DateTime.Now;
      public double BasicSalary { get; set; }
      public double OverTime { get; set; }
      public double Deduction { get; set; }
      public double NetSalary { get; set; }

      public required Employee Employee { get; set; }
      public required Summary Summary { get; set; }
}

