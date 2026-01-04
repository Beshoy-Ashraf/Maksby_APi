using Maksby.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.ExpensesConfigration;

public class ConfigrationForExpense : IEntityTypeConfiguration<Expense>
{
      public void Configure(EntityTypeBuilder<Expense> builder)
      {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.HasOne(x => x.Summary)
                   .WithMany(e => e.Expenses)
                   .HasForeignKey(f => f.SummaryId)
                   .OnDelete(DeleteBehavior.Restrict);

      }
}
