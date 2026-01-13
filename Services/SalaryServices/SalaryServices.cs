using Maksby.Contract.Employee;
using Maksby.Contract.Salary;
using Maksby.Data.Context;
using Maksby.Data.Models.Employee;
using Maksby.Services.SalaryServices.Interface;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Services.SalaryServices;

public class SalaryServices : ISalaryServices
{

      private readonly AppDBContext _dbContext;
      private readonly IServiceProvider _serviceProvider;
      private readonly ILogger<SalaryServices> _logger;

      public SalaryServices(AppDBContext dbContext, IServiceProvider serviceProvider, ILogger<SalaryServices> logger)
      {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            _logger = logger;
      }
      public async Task<Guid> AddSalary(AddSalaryRequest addSalaryRequest, CancellationToken cancellationToken)
      {
            var summary = await _dbContext.Summaries.FirstOrDefaultAsync(cancellationToken) ?? throw new KeyNotFoundException($"summary Not Found");
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == addSalaryRequest.EmployeeId, cancellationToken) ?? throw new KeyNotFoundException($"Employee with {addSalaryRequest.EmployeeId} not found");

            var NewSalary = new Salary
            {
                  BasicSalary = addSalaryRequest.BasicSalary,
                  OverTime = addSalaryRequest.OverTime,
                  Deduction = addSalaryRequest.Deduction,
                  NetSalary = addSalaryRequest.BasicSalary + addSalaryRequest.OverTime - addSalaryRequest.Deduction,
                  Summary = summary,
                  Employee = employee
            };
            await _dbContext.Salaries.AddAsync(NewSalary, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return NewSalary.Id;

      }
      public async Task<Guid> EditSalary(Guid id, AddSalaryRequest addSalaryRequest, CancellationToken cancellationToken)
      {
            var summary = await _dbContext.Summaries.FirstOrDefaultAsync(cancellationToken) ?? throw new KeyNotFoundException($"summary Not Found");
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == addSalaryRequest.EmployeeId, cancellationToken) ?? throw new KeyNotFoundException($"Employee with {addSalaryRequest.EmployeeId} not found");
            var salary = await _dbContext.Salaries.FirstOrDefaultAsync(x => x.Id == id, cancellationToken) ?? throw new KeyNotFoundException($"Salary with {id} not found");

            salary.BasicSalary = addSalaryRequest.BasicSalary;
            salary.NetSalary = addSalaryRequest.BasicSalary + addSalaryRequest.OverTime - addSalaryRequest.Deduction;
            salary.OverTime = addSalaryRequest.OverTime;
            salary.Deduction = addSalaryRequest.Deduction;

            salary.Summary = summary;
            salary.Employee = employee;

            _dbContext.Salaries.Update(salary);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return salary.Id;
      }
      public async Task<GetSalaryRequest> GetSalary(Guid id, CancellationToken cancellationToken)
      {
            var tmp = await _dbContext.Salaries
            .Where(x => x.Id == id)
                .Include(ci => ci.Employee)
                .Select(
                x => new GetSalaryRequest
                {
                      Id = x.Id,
                      BasicSalary = x.BasicSalary,
                      NetSalary = x.NetSalary,
                      OverTime = x.OverTime,
                      Deduction = x.Deduction,
                      EmployeeId = x.Employee.Id
                }
                )
                .FirstOrDefaultAsync(cancellationToken) ?? throw new KeyNotFoundException($"Salary with {id} not found");
            return tmp;
      }
      public async Task<List<GetSalaryRequest>> GetSalaries(CancellationToken cancellationToken)
      {
            var tmp = await _dbContext.Salaries
                .Include(ci => ci.Employee)
                .Select(
                x => new GetSalaryRequest
                {
                      Id = x.Id,
                      BasicSalary = x.BasicSalary,
                      NetSalary = x.NetSalary,
                      OverTime = x.OverTime,
                      Deduction = x.Deduction,
                      EmployeeId = x.Employee.Id
                }
                )
                .ToListAsync(cancellationToken);

            return tmp;
      }
}
