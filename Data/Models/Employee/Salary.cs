namespace Maksby.Data.Models;

public class Salary
{
      public int id { get; set; }
      public int SummaryId { get; set; }
      public int EmployeeId { get; set; }
      public DateTime date { get; set; }
      public double BasicSalary { get; set; }
      public double OverTime { get; set; }
      public double Deduction { get; set; }
      public double NetSalary { get; set; }
}
