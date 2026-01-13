using Maksby.Contract.Employee;
using Maksby.Services.DebtServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.EmployeeController;


public partial class EmployeeController : ControllerBase
{
      [HttpPost]

      public async Task<Guid> AddEmployee([FromBody] AddEmployeeRequest addEmployeeRequest, CancellationToken cancellationToken)
      {
            return await _services.AddEmployee(addEmployeeRequest, cancellationToken);
      }


}
