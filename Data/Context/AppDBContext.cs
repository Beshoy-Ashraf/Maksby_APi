using Microsoft.EntityFrameworkCore;
using Maksby.Data.Models.Employee;
using Maksby.Data.Models;
using Maksby.Data.Models.User;
using Maksby.Data.Models.batch;
using Maksby.Data.Models.Debt;
using Maksby.Data.Models.Income;

namespace Maksby.Data.Context;

public class AppDBContext : DbContext
{
      public DbSet<Batch> Batches { get; set; }
      public DbSet<BatchItem> BatchItems { get; set; }
      public DbSet<DebtInvoice> DebtInvoices { get; set; }
      public DbSet<DebtTransaction> DebtTransactions { get; set; }
      public DbSet<Item> Items { get; set; }
      public DbSet<Supplier> Suppliers { get; set; }
      public DbSet<Employee> Employees { get; set; }
      public DbSet<Salary> Salaries { get; set; }
      public DbSet<Expense> Expenses { get; set; }
      public DbSet<Client> Clients { get; set; }
      public DbSet<ClientInvoice> ClientInvoices { get; set; }
      public DbSet<ClientInvoiceProduct> ClientInvoiceProducts { get; set; }
      public DbSet<ClientTransaction> ClientTransactions { get; set; }
      public DbSet<Product> Products { get; set; }
      public DbSet<User> Users { get; set; }
      public DbSet<Summary> Summaries { get; set; }


      public AppDBContext(DbContextOptions options) : base(options)
      {

      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
      }
}
