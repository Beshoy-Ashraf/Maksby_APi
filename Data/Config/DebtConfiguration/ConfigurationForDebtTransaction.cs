using Maksby.Data.Models.Debt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.DebtConfiguration;

public class ConfigurationForDebtTransaction : IEntityTypeConfiguration<DebtTransaction>
{
      public void Configure(EntityTypeBuilder<DebtTransaction> builder)
      {
            builder.HasKey(x => x.Id);


            builder.HasOne(x => x.Supplier)
                   .WithMany(t => t.DebtTransactions);

            builder.HasOne(x => x.DebtInvoice)
                   .WithMany(t => t.DebtTransactions);
      }
}