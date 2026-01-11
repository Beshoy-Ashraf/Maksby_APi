using Maksby.Contract.Client;

namespace Maksby.Services.IncomeServices.Interfaces;

public interface IClientService
{
      Task<Guid> AddClient(ClientRequest ClientRequest, CancellationToken cancellationToken);
      Task<Guid> EditClient(Guid id, ClientRequest ClientRequest, CancellationToken cancellationToken);
      Task<ClientRequest> GetClient(Guid id, CancellationToken cancellationToken);
      Task<List<ClientRequest>> GetClients(CancellationToken cancellationToken);
}
