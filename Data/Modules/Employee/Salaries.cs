namespace Maksby.Data.Modules;

public class Salaries
{
      public int id { get; set; }
      public int Summary_Id { get; set; }
      public int Employee_Id { get; set; }
      public DateTime date { get; set; }
      public double Basic_Salary { get; set; }
      public double Over_Time { get; set; }
      public double Deduction { get; set; }
      public double Net_Salary { get; set; }
}
