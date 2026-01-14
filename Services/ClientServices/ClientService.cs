using Maksby.Contract.Client;
using Maksby.Data.Context;
using Maksby.Data.Models.Income;
using Maksby.Services.ClientServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Services.ClientServices;

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
      public async Task<Guid> AddClient(AddClientRequest addClientRequest, CancellationToken cancellationToken)
      {
            var client = new Client
            {
                  Name = addClientRequest.Name,
                  Balance = addClientRequest.Balance,
                  UpdatedDate = DateTime.UtcNow,
                  DeletedDate = DateTime.UtcNow,

            };
            await _dbContext.Clients.AddAsync(client, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return client.Id;

      }
      public async Task<Guid> EditClient(Guid id, AddClientRequest addClientRequest, CancellationToken cancellationToken)
      {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (client == null)
            {
                  throw new Exception("Client not found");
            }

            client.Name = addClientRequest.Name;
            //if any issues appear
            client.Balance = addClientRequest.Balance;
            client.UpdatedDate = DateTime.UtcNow;

            _dbContext.Clients.Update(client);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return client.Id;
      }
      public async Task<GetClientRequest> GetClient(Guid id, CancellationToken cancellationToken)
      {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (client == null)
            {
                  throw new Exception("Client not found");
            }

            var retrieveClient = new GetClientRequest
            {
                  Id = client.Id,
                  Name = client.Name,
                  Balance = client.Balance,
            };


            return retrieveClient;
      }
      public async Task<List<GetClientRequest>> GetClients(CancellationToken cancellationToken)
      {
            var client = await _dbContext.Clients.ToListAsync(cancellationToken);
            if (client == null)
            {
                  throw new Exception("Client not found");
            }
            List<GetClientRequest> clientList = new List<GetClientRequest>();
            foreach (var ele in client)
            {
                  var retrieveClient = new GetClientRequest
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
