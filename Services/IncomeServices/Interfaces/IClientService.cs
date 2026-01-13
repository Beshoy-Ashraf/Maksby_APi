using Maksby.Contract.Client;

namespace Maksby.Services.IncomeServices.Interfaces;

public interface IClientService
{
      Task<Guid> AddClient(AddClientRequest addClientRequest, CancellationToken cancellationToken);
      Task<Guid> EditClient(Guid id, AddClientRequest addClientRequest, CancellationToken cancellationToken);
      Task<GetClientRequest> GetClient(Guid id, CancellationToken cancellationToken);
      Task<List<GetClientRequest>> GetClients(CancellationToken cancellationToken);
}
