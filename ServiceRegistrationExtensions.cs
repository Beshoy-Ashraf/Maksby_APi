using Maksby.Data.Context;
using Maksby.Data.Models;
using Maksby.Services.ClientServices;
using Maksby.Services.ClientServices.Interfaces;
using Maksby.Services.DebtServices;
using Maksby.Services.DebtServices.Interface;
using Maksby.Services.EmployeeServices;
using Maksby.Services.EmployeeServices.Interface;
using Maksby.Services.ExpensesServices;
using Maksby.Services.ExpensesServices.Interface;
using Maksby.Services.IncomeServices;
using Maksby.Services.IncomeServices.Interfaces;
using Maksby.Services.ItemServices;
using Maksby.Services.ItemServices.Interface;
using Maksby.Services.ProductServices;
using Maksby.Services.ProductServices.Interface;
using Maksby.Services.SalaryServices;
using Maksby.Services.SalaryServices.Interface;
using Maksby.Services.SummaryServices;
using Maksby.Services.SummaryServices.Interface;

namespace Maksby;

public static class ServiceRegistrationExtensions
{

      public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
      {

            services.AddScoped<IIncomeServices, IncomeServices>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IExpensesServices, ExpensesServices>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<ISalaryServices, SalaryServices>();
            services.AddScoped<IDebtServices, DebtServices>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ISummaryServices, SummaryServices>();

            return services;
      }
}
