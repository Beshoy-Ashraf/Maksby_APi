using Maksby.Data.Models.Income;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.IncomConfigration;

public class ConfigrationForClientInvoicesProduct : IEntityTypeConfiguration<ClientInvoiceProduct>
{
      public void Configure(EntityTypeBuilder<ClientInvoiceProduct> builder)
      {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.HasOne(x => x.Product)
                   .WithMany(b => b.ClientInvoiceProducts)
                   .HasForeignKey(f => f.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ClientInvoice)
                   .WithMany(i => i.ClientInvoiceProducts)
                   .HasForeignKey(f => f.ClientInvoiceId)
                   .OnDelete(DeleteBehavior.Restrict);
      }
}

