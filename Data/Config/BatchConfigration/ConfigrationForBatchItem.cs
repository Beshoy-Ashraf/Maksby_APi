using Maksby.Data.Models.batch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.BatchConfigration;

public class ConfigrationForBatchItem : IEntityTypeConfiguration<BatchItem>
{
      public void Configure(EntityTypeBuilder<BatchItem> builder)
      {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.HasOne(x => x.Item)
                   .WithMany(b => b.BatchItems)
                   .HasForeignKey(f => f.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Batch)
           .WithMany(b => b.BatchItems)
           .HasForeignKey(f => f.BatchId)
           .OnDelete(DeleteBehavior.Restrict);
      }
}
