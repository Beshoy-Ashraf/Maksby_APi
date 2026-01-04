using Maksby.Data.Models.Debt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.DebtConfigration;

public class ConfigrationForDebtInvoiceItem : IEntityTypeConfiguration<DebtInvoiceItem>
{
      public void Configure(EntityTypeBuilder<DebtInvoiceItem> builder)
      {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.HasOne(x => x.DebtInvoice)
                   .WithMany(i => i.DebtInvoiceItems)
                   .HasForeignKey(x => x.InvoicesId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Items)
                  .WithMany(x => x.DebtInvoiceItem)
                  .HasForeignKey(x => x.ItemId)
                  .OnDelete(DeleteBehavior.Restrict);
      }
}
