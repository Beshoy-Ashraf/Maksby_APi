using Maksby.Data.Models;
using Maksby.Data.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.UserConfigration;

public class ConfigrationForUser : IEntityTypeConfiguration<User>
{
      public void Configure(EntityTypeBuilder<User> builder)
      {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.HasOne(x => x.Summary)
                   .WithOne(u => u.User)
                   .HasForeignKey<Summary>(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
      }
}

