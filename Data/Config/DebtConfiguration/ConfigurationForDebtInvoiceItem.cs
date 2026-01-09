using Maksby.Data.Models.Debt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.DebtConfiguration;

public class ConfigurationForDebtInvoiceItem : IEntityTypeConfiguration<DebtInvoiceItem>
{
      public void Configure(EntityTypeBuilder<DebtInvoiceItem> builder)
      {
            builder.HasKey(x => x.Id);


            builder.HasOne(x => x.DebtInvoice)
                   .WithMany(i => i.DebtInvoiceItems);

            builder.HasOne(x => x.Items)
                  .WithMany(x => x.DebtInvoiceItem);
      }
}
