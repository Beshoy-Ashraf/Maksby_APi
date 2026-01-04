using Maksby.Data.Models.Debt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.DebtConfigration;

public class ConfigrationForDebtInvoices : IEntityTypeConfiguration<DebtInvoice>
{
      public void Configure(EntityTypeBuilder<DebtInvoice> builder)
      {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.HasOne(x => x.Summary)
                   .WithMany(i => i.DebtInvoices)
                   .HasForeignKey(x => x.SummaryId);
      }
}
