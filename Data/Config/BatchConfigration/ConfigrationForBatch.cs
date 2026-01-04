using Maksby.Data.Models.batch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.BatchConfigration;

public class ConfigrationForBatch : IEntityTypeConfiguration<Batch>
{
      public void Configure(EntityTypeBuilder<Batch> builder)
      {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.HasOne(x => x.Product)
                   .WithMany(b => b.Batches)
                   .HasForeignKey(f => f.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
      }
}

