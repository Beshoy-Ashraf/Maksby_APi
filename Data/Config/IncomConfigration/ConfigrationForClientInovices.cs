using Maksby.Data.Models.Income;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.IncomConfigration;

public class ConfigrationForClientInovices : IEntityTypeConfiguration<ClientInvoice>
{
      public void Configure(EntityTypeBuilder<ClientInvoice> builder)
      {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.HasOne(x => x.Summary)
                   .WithMany(c => c.ClientInvoices)
                   .HasForeignKey(f => f.SummrayId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Client)
                   .WithMany(s => s.ClientInvoices)
                   .HasForeignKey(f => f.ClientId)
                   .OnDelete(DeleteBehavior.Restrict);
      }
}
