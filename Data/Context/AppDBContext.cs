using Microsoft.EntityFrameworkCore;

namespace Maksby.Data.Context;

public class AppDBContext : DbContext
{
      public AppDBContext(DbContextOptions options) : base(options)
      {

      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
            base.OnModelCreating(modelBuilder);
      }
}