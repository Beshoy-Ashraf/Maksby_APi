using Maksby.Data.Models.batch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.BatchConfiguration;

public class ConfigurationForBatchItem : IEntityTypeConfiguration<BatchItem>
{
       public void Configure(EntityTypeBuilder<BatchItem> builder)
       {
              builder.HasKey(x => x.Id);


              builder.HasOne(i => i.Item)
                     .WithMany(b => b.BatchItems);

              builder.HasOne(b => b.Batch)
             .WithMany(bi => bi.BatchItems);
       }
}
