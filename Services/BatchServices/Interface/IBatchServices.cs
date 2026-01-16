using Maksby.Contract.Batch;

namespace Maksby.Services.BatchServices.Interface;

public interface IBatchServices
{
      Task<Guid> AddBatch(AddBatchRequest addBatchRequest, CancellationToken cancellationToken);
      Task<Guid> EditBatch(Guid id, AddBatchRequest addBatchRequest, CancellationToken cancellationToken);
      Task<GetBatchRequest> GetBatch(Guid id, CancellationToken cancellationToken);
      Task<List<GetBatchRequest>> GetBatches(CancellationToken cancellationToken);


}
