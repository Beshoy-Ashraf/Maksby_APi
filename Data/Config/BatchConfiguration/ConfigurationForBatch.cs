using Maksby.Data.Models.batch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.BatchConfiguration;

public class ConfigurationForBatch : IEntityTypeConfiguration<Batch>
{
      public void Configure(EntityTypeBuilder<Batch> builder)
      {
            builder.HasKey(x => x.Id);


            builder.HasOne(p => p.Product)
                   .WithMany(b => b.Batches);
      }
}

