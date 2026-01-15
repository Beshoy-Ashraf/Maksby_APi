using System.Security.Cryptography.X509Certificates;
using Maksby.Contract.Summary;
using Maksby.Data.Context;
using Maksby.Services.SummaryServices.Interface;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Services.SummaryServices;

public class SummaryServices : ISummaryServices
{
      private readonly AppDBContext _dbContext;
      private readonly IServiceProvider _serviceProvider;
      private readonly ILogger<SummaryServices> _logger;

      public SummaryServices(AppDBContext dbContext, IServiceProvider serviceProvider, ILogger<SummaryServices> logger)
      {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            _logger = logger;
      }
      public async Task<GetSummaryRequest> GetSummary(CancellationToken cancellationToken)
      {
            var summary = await _dbContext.Summaries.FirstAsync(cancellationToken);
            var response = new GetSummaryRequest
            {
                  Id = summary.Id,
                  InitialValue = summary.InitialValue,
                  ActualIncome = summary.ActualIncome,
                  ActualDebt = summary.ActualDebt,
                  EstimatedDebt = summary.EstimatedDebt,
                  EstimatedIncome = summary.EstimatedDebt,
                  TotalExpenses = summary.TotalSalaries,
                  TotalSalaries = summary.TotalSalaries
            };
            return response;
      }
}
