using Maksby.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.ExpensesConfiguration;

public class ConfigurationForExpense : IEntityTypeConfiguration<Expense>
{
      public void Configure(EntityTypeBuilder<Expense> builder)
      {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Summary)
                   .WithMany(e => e.Expenses);

      }
}
