using Maksby.Contract.Summary;

namespace Maksby.Services.SummaryServices.Interface;

public interface ISummaryServices
{
      Task<GetSummaryRequest> GetSummary(CancellationToken cancellationToken);
}
