using Maksby.Data.Models.Debt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.DebtConfigration;

public class ConfigrationForSupplier : IEntityTypeConfiguration<Supplier>
{
      public void Configure(EntityTypeBuilder<Supplier> builder)
      {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                    .ValueGeneratedNever();

            builder.HasMany(x => x.DebtInvoices)
                   .WithOne(x => x.Supplier)
                   .HasForeignKey(f => f.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict);

      }
}
