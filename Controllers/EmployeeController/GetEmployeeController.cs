using Maksby.Contract.Employee;
using Maksby.Services.DebtServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Controllers.EmployeeController;


public partial class EmployeeController : ControllerBase
{
      [HttpGet("{Id:guid}")]

      public async Task<GetEmployeeRequest> GetEmployee([FromRoute] Guid id, CancellationToken cancellationToken)
      {
            return await _services.GetEmployee(id, cancellationToken);
      }
      [HttpGet]

      public async Task<List<GetEmployeeRequest>> GetEmployees(CancellationToken cancellationToken)
      {
            return await _services.GetEmployees(cancellationToken);
      }


}
