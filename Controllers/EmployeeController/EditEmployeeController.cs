using Maksby.Contract.Employee;
using Maksby.Services.DebtServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.EmployeeController;


public partial class EmployeeController : ControllerBase
{
      [HttpPut("{id:guid}")]

      public async Task<Guid> EditEmployee([FromRoute] Guid id, AddEmployeeRequest addEmployeeRequest, CancellationToken cancellationToken)
      {
            return await _services.EditEmployee(id, addEmployeeRequest, cancellationToken);
      }


}
