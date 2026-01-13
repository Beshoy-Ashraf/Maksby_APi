
using Maksby.Contract.Item;
using Maksby.Data.Context;
using Maksby.Data.Models.Debt;
using Maksby.Services.ItemServices.Interface;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Services.ItemServices;

public class ItemService : IItemService
{
      private readonly AppDBContext _dbContext;
      private readonly IServiceProvider _serviceProvider;
      private readonly ILogger<ItemService> _logger;

      public ItemService(AppDBContext dbContext, IServiceProvider serviceProvider, ILogger<ItemService> logger)
      {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            _logger = logger;
      }
      public async Task<Guid> AddItem(AddItemRequest addItemRequest, CancellationToken cancellationToken)
      {
            var item = new Item
            {
                  Name = addItemRequest.Name,
                  QuantityPerKilo = addItemRequest.QuantityPerKilo,
                  PricePerKilo = addItemRequest.PricePerKilo,
                  Description = addItemRequest.Description,
                  UpdatedDate = DateTime.UtcNow,
                  DeletedDate = DateTime.UtcNow,

            };
            await _dbContext.Items.AddAsync(item, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return item.Id;

      }
      public async Task<Guid> EditItem(Guid id, AddItemRequest addItemRequest, CancellationToken cancellationToken)
      {
            var item = await _dbContext.Items.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (item == null)
            {
                  throw new Exception("Item not found");
            }

            item.Name = addItemRequest.Name;
            item.QuantityPerKilo = addItemRequest.QuantityPerKilo;
            item.PricePerKilo = addItemRequest.PricePerKilo;
            item.Description = addItemRequest.Description;
            item.UpdatedDate = DateTime.UtcNow;

            _dbContext.Items.Update(item);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return item.Id;
      }
      public async Task<GetItemRequest> GetItem(Guid id, CancellationToken cancellationToken)
      {
            var item = await _dbContext.Items.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (item == null)
            {
                  throw new Exception("Item not found");
            }

            var retrieveItem = new GetItemRequest
            {
                  Id = item.Id,
                  Name = item.Name,
                  Description = item.Description,
                  PricePerKilo = item.PricePerKilo,
                  QuantityPerKilo = item.QuantityPerKilo
            };


            return retrieveItem;
      }
      public async Task<List<GetItemRequest>> GetItems(CancellationToken cancellationToken)
      {
            var item = await _dbContext.Items.ToListAsync(cancellationToken);
            if (item == null)
            {
                  throw new Exception("Item not found");
            }
            List<GetItemRequest> itemList = new List<GetItemRequest>();
            foreach (var ele in item)
            {
                  var retrieveItem = new GetItemRequest
                  {
                        Id = ele.Id,
                        Name = ele.Name,
                        Description = ele.Description,
                        PricePerKilo = ele.PricePerKilo,
                        QuantityPerKilo = ele.QuantityPerKilo
                  };
                  itemList.Add(retrieveItem);
            }
            return itemList;
      }
}
