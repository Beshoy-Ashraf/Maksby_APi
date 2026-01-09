using Maksby.Contract;
using Maksby.Data.Models.Debt;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Services.IncomeServices.Interfaces;

public interface IIncomeServices
{
      Task<List<DebtInvoice>> Get();
      Task<Guid> Add(AddInvoiceRequest addInvoiceRequest, CancellationToken cancellationToken);

}
