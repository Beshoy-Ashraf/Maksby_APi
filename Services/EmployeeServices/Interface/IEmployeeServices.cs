using Maksby.Contract.Employee;

namespace Maksby.Services.EmployeeServices.Interface;

public interface IEmployeeServices
{
      Task<Guid> AddEmployee(AddEmployeeRequest EmployeeRequest, CancellationToken cancellationToken);
      Task<Guid> EditEmployee(Guid id, AddEmployeeRequest EmployeeRequest, CancellationToken cancellationToken);
      Task<GetEmployeeRequest> GetEmployee(Guid id, CancellationToken cancellationToken);
      Task<List<GetEmployeeRequest>> GetEmployees(CancellationToken cancellationToken);
}
