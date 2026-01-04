using Maksby.Data.Models.Debt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.DebtConfigration;

public class ConfigrationForDebtTransaction : IEntityTypeConfiguration<DebtTransaction>
{
      public void Configure(EntityTypeBuilder<DebtTransaction> builder)
      {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.HasOne(x => x.Supplier)
                   .WithMany(t => t.DebtTransactions)
                   .HasForeignKey(x => x.SupplierId);
      }
}