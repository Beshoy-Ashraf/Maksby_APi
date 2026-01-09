using Maksby.Data.Models.Income;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.IncomeConfiguration;

public class ConfigurationForClientInvoices : IEntityTypeConfiguration<ClientInvoice>
{
       public void Configure(EntityTypeBuilder<ClientInvoice> builder)
       {
              builder.HasKey(x => x.Id);

              builder.HasOne(x => x.Summary)
                     .WithMany(c => c.ClientInvoices);

              builder.HasOne(x => x.Client)
                     .WithMany(s => s.ClientInvoices);
       }
}
