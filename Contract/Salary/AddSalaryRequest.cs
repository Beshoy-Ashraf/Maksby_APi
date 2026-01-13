namespace Maksby.Contract.Salary;

public class AddSalaryRequest
{
      public Guid EmployeeId { get; set; }
      public double BasicSalary { get; set; }
      public double OverTime { get; set; }
      public double Deduction { get; set; }
}
