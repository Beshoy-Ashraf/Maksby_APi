using Maksby.Data.Models;
using Maksby.Data.Models.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.EmployeeConfiguration;

public class ConfigurationForSalary : IEntityTypeConfiguration<Salary>
{
       public void Configure(EntityTypeBuilder<Salary> builder)
       {
              builder.ToTable("Salaries");

              builder.HasKey(x => x.Id);

              builder.HasOne(x => x.Employee)
                     .WithMany(e => e.Salaries);

              builder.HasOne(x => x.Summary)
                     .WithMany(s => s.Salaries);

       }
}

