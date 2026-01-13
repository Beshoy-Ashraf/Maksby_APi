using Maksby.Contract.Salary;
using Maksby.Services.DebtServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.SalaryController;


public partial class SalaryController : ControllerBase
{
      [HttpGet("{Id:guid}")]

      public async Task<GetSalaryRequest> GetSalary([FromRoute] Guid id, CancellationToken cancellationToken)
      {
            return await _services.GetSalary(id, cancellationToken);
      }
      [HttpGet]

      public async Task<List<GetSalaryRequest>> GetSalaries(CancellationToken cancellationToken)
      {
            return await _services.GetSalaries(cancellationToken);
      }


}
