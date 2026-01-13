using Maksby.Contract.Employee;
using Maksby.Data.Context;
using Maksby.Data.Models.Employee;
using Maksby.Services.EmployeeServices.Interface;
using Microsoft.EntityFrameworkCore;
namespace Maksby.Services.EmployeeServices;

public class EmployeeServices : IEmployeeServices
{
      private readonly AppDBContext _dbContext;
      private readonly IServiceProvider _serviceProvider;
      private readonly ILogger<EmployeeServices> _logger;

      public EmployeeServices(AppDBContext dbContext, IServiceProvider serviceProvider, ILogger<EmployeeServices> logger)
      {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            _logger = logger;
      }
      public async Task<Guid> AddEmployee(AddEmployeeRequest addEmployeeRequest, CancellationToken cancellationToken)
      {
            var employee = new Employee
            {
                  FirstName = addEmployeeRequest.FirstName,
                  LastName = addEmployeeRequest.LastName,

            };
            await _dbContext.Employees.AddAsync(employee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return employee.Id;
      }




      public async Task<Guid> EditEmployee(Guid id, AddEmployeeRequest addEmployeeRequest, CancellationToken cancellationToken)
      {
            var employee = await _dbContext.Employees.SingleOrDefaultAsync(c => c.Id == id);
            if (employee == null)
            {
                  throw new Exception("Employee not found");
            }

            employee.FirstName = addEmployeeRequest.FirstName;
            employee.LastName = addEmployeeRequest.LastName;
            employee.UpdatedDate = DateTime.UtcNow;

            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return employee.Id;
      }
      public async Task<GetEmployeeRequest> GetEmployee(Guid id, CancellationToken cancellationToken)
      {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (employee == null)
            {
                  throw new Exception("Employee not found");
            }

            var retrieveEmployee = new GetEmployeeRequest
            {
                  Id = employee.Id,
                  FirstName = employee.FirstName,
                  LastName = employee.LastName,
            };


            return retrieveEmployee;
      }
      public async Task<List<GetEmployeeRequest>> GetEmployees(CancellationToken cancellationToken)
      {
            var employee = await _dbContext.Employees.ToListAsync(cancellationToken);
            if (employee == null)
            {
                  throw new Exception("Employee not found");
            }
            List<GetEmployeeRequest> EmployeeList = [];
            foreach (var ele in employee)
            {
                  var retrieveEmployee = new GetEmployeeRequest
                  {
                        Id = ele.Id,
                        FirstName = ele.FirstName,
                        LastName = ele.LastName,
                  };
                  EmployeeList.Add(retrieveEmployee);
            }
            return EmployeeList;
      }
}
