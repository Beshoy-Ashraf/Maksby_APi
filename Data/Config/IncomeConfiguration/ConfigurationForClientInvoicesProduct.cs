using Maksby.Data.Models.Income;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maksby.Data.Config.IncomeConfiguration;

public class ConfigurationForClientInvoicesProduct : IEntityTypeConfiguration<ClientInvoiceProduct>
{
       public void Configure(EntityTypeBuilder<ClientInvoiceProduct> builder)
       {
              builder.HasKey(x => x.Id);

              builder.HasOne(x => x.Product)
                     .WithMany(b => b.ClientInvoiceProducts);

              builder.HasOne(x => x.ClientInvoice)
                     .WithMany(i => i.ClientInvoiceProducts);
       }
}

