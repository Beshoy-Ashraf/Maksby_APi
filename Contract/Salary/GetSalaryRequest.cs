namespace Maksby.Contract.Salary;

public class GetSalaryRequest
{
      public Guid Id { get; set; }
      public Guid EmployeeId { get; set; }
      public double BasicSalary { get; set; }
      public double OverTime { get; set; }
      public double Deduction { get; set; }
      public double NetSalary { get; set; }

}
