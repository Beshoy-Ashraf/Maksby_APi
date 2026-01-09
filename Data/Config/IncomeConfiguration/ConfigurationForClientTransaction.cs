using Maksby.Data.Models.Income;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.IncomeConfiguration;

public class ConfigurationForClientTransaction : IEntityTypeConfiguration<ClientTransaction>
{
       public void Configure(EntityTypeBuilder<ClientTransaction> builder)
       {
              builder.HasKey(x => x.Id);

              builder.HasOne(x => x.ClientInvoice)
                     .WithMany(t => t.ClientTransactions);

              builder.HasOne(x => x.Client)
                     .WithMany(t => t.ClientTransactions);


       }
}