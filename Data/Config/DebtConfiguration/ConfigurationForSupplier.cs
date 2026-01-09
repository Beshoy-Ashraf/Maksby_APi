using Maksby.Data.Models.Debt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.DebtConfiguration;

public class ConfigurationForSupplier : IEntityTypeConfiguration<Supplier>
{
      public void Configure(EntityTypeBuilder<Supplier> builder)
      {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.DebtInvoices)
                   .WithOne(x => x.Supplier);

      }
}
