using Maksby.Contract.Batch;
using Maksby.Data.Models.batch;

namespace Maksby.Services.BatchServices.Interface;

public interface IBatchServices
{
      Task<Guid> AddBatch(AddBatchRequest addBatchRequest, CancellationToken cancellationToken);
      Task<Guid> EditBatch(Guid id, AddBatchRequest addBatchRequest, CancellationToken cancellationToken);
      Task<GetBatchRequest> GetBatch(Guid id, CancellationToken cancellationToken);
      Task<List<GetBatchRequest>> GetBatches(CancellationToken cancellationToken);
      Task<Guid> ChangeBatchStatus(Guid id, BatchStatus status, CancellationToken cancellationToken);


}
