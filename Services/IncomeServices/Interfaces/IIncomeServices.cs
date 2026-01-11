using Maksby.Contract;
using Maksby.Contract.Income;
using Maksby.Data.Models.Debt;
using Microsoft.AspNetCore.Mvc;

namespace Maksby.Services.IncomeServices.Interfaces;

public interface IIncomeServices
{
      Task<List<GetInvoicesResponse>> GetInvoices(CancellationToken cancellationToken);
      Task<Guid> Add(AddInvoiceRequest addInvoiceRequest, CancellationToken cancellationToken);
      Task<List<GetInvoicesResponse>> GetInvoice(Guid Id, CancellationToken cancellationToken);
      Task<Guid> EditInvoice(AddInvoiceRequest addInvoiceRequest, Guid Id, CancellationToken cancellationToken);
}
