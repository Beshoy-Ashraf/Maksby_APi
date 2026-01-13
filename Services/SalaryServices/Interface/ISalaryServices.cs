using Maksby.Contract.Salary;

namespace Maksby.Services.SalaryServices.Interface;

public interface ISalaryServices
{
      Task<Guid> AddSalary(AddSalaryRequest addSalaryRequest, CancellationToken cancellationToken);

      Task<Guid> EditSalary(Guid id, AddSalaryRequest SalaryRequest, CancellationToken cancellationToken);
      Task<GetSalaryRequest> GetSalary(Guid id, CancellationToken cancellationToken);
      Task<List<GetSalaryRequest>> GetSalaries(CancellationToken cancellationToken);
}
