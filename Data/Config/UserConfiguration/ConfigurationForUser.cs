using Maksby.Data.Models;
using Maksby.Data.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.UserConfiguration;

public class ConfigurationForUser : IEntityTypeConfiguration<User>
{
      public void Configure(EntityTypeBuilder<User> builder)
      {
            builder.HasKey(x => x.Id);

      }
}

