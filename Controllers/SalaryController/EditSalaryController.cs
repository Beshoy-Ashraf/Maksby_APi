using Maksby.Contract.Salary;
using Maksby.Services.DebtServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.SalaryController;


public partial class SalaryController : ControllerBase
{
      [HttpPut("{id:guid}")]

      public async Task<Guid> EditSalary([FromRoute] Guid id, AddSalaryRequest addSalaryRequest, CancellationToken cancellationToken)
      {
            return await _services.EditSalary(id, addSalaryRequest, cancellationToken);
      }


}
