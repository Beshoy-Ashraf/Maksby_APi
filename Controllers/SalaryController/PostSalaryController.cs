using Maksby.Contract.Salary;
using Maksby.Services.DebtServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.SalaryController;


public partial class SalaryController : ControllerBase
{
      [HttpPost]

      public async Task<Guid> AddSalary([FromBody] AddSalaryRequest addSalaryRequest, CancellationToken cancellationToken)
      {
            return await _services.AddSalary(addSalaryRequest, cancellationToken);
      }


}
