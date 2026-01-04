using Maksby.Data.Models;
using Maksby.Data.Models.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.EmployeeConfigration;

public class ConfogrationForSalary : IEntityTypeConfiguration<Salary>
{
       public void Configure(EntityTypeBuilder<Salary> builder)
       {
              builder.ToTable("Salaries");

              builder.HasKey(x => x.id);
              builder.Property(x => x.id)
                     .ValueGeneratedNever();

              builder.HasOne(x => x.Employee)
                     .WithMany(e => e.Salaries)
                     .HasForeignKey(x => x.EmployeeId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasOne(x => x.Summary)
                     .WithMany(s => s.Salaries)
                     .HasForeignKey(f => f.SummaryId)
                     .OnDelete(DeleteBehavior.Restrict);

       }
}

