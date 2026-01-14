using Maksby.Data.Context;

using Maksby.Services.EmployeeServices;
using Maksby.Services.EmployeeServices.Interface;
using Maksby.Services.ExpensesServices;
using Maksby.Services.ExpensesServices.Interface;
using Maksby.Services.IncomeServices;
using Maksby.Services.IncomeServices.Interfaces;
using Maksby.Services.ProductServices;
using Maksby.Services.ProductServices.Interface;
using Maksby.Services.SalaryServices;
using Maksby.Services.SalaryServices.Interface;

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

            return services;
      }
}
