using Maksby.Contract.Client;
using Maksby.Data.Context;
using Maksby.Data.Models.Income;
using Maksby.Services.IncomeServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Services.IncomeServices;

public class ClientService : IClientService
{
      private readonly AppDBContext _dbContext;
      private readonly IServiceProvider _serviceProvider;
      private readonly ILogger<ClientService> _logger;

      public ClientService(AppDBContext dbContext, IServiceProvider serviceProvider, ILogger<ClientService> logger)
      {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            _logger = logger;
      }
      public async Task<Guid> AddClient(ClientRequest ClientRequest, CancellationToken cancellationToken)
      {
            var client = new Client
            {
                  Name = ClientRequest.Name,
                  Balance = ClientRequest.Balance,
                  UpdatedDate = DateTime.UtcNow,
                  DeletedDate = DateTime.UtcNow,

            };
            await _dbContext.Clients.AddAsync(client, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return client.Id;

      }
      public async Task<Guid> EditClient(Guid id, ClientRequest ClientRequest, CancellationToken cancellationToken)
      {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (client == null)
            {
                  throw new Exception("Client not found");
            }

            client.Name = ClientRequest.Name;
            client.Balance = ClientRequest.Balance;
            client.UpdatedDate = DateTime.UtcNow;

            _dbContext.Clients.Update(client);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return client.Id;
      }
      public async Task<ClientRequest> GetClient(Guid id, CancellationToken cancellationToken)
      {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (client == null)
            {
                  throw new Exception("Client not found");
            }

            var retrieveClient = new ClientRequest
            {
                  Id = client.Id,
                  Name = client.Name,
                  Balance = client.Balance,
            };


            return retrieveClient;
      }
      public async Task<List<ClientRequest>> GetClients(CancellationToken cancellationToken)
      {
            var client = await _dbContext.Clients.ToListAsync(cancellationToken);
            if (client == null)
            {
                  throw new Exception("Client not found");
            }
            List<ClientRequest> clientList = new List<ClientRequest>();
            foreach (var ele in client)
            {
                  var retrieveClient = new ClientRequest
                  {
                        Id = ele.Id,
                        Name = ele.Name,
                        Balance = ele.Balance,
                  };
                  clientList.Add(retrieveClient);
            }
            return clientList;
      }


}
