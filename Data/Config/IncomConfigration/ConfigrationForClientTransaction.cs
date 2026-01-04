using Maksby.Data.Models.Income;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.IncomConfigration;

public class ConfigrationForClientTransaction : IEntityTypeConfiguration<ClientTransaction>
{
      public void Configure(EntityTypeBuilder<ClientTransaction> builder)
      {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.HasOne(x => x.ClientInvoice)
                   .WithMany(t => t.ClientTransactions)
                   .HasForeignKey(f => f.ClientInvoiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Client)
                   .WithMany(t => t.ClientTransactions)
                   .HasForeignKey(f => f.ClientId)
                   .OnDelete(DeleteBehavior.Restrict);


      }
}