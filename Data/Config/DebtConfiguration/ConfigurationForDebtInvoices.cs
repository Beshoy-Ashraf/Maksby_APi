using Maksby.Data.Models.Debt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.DebtConfiguration;

public class ConfigurationForDebtInvoices : IEntityTypeConfiguration<DebtInvoice>
{
      public void Configure(EntityTypeBuilder<DebtInvoice> builder)
      {
            builder.HasKey(x => x.Id);


            builder.HasOne(x => x.Summary)
                   .WithMany(i => i.DebtInvoices);
      }
}
