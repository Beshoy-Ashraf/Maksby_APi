

using Maksby.Contract.Item;

namespace Maksby.Services.ItemServices.Interface;

public interface IItemService
{

      Task<Guid> AddItem(AddItemRequest ItemRequest, CancellationToken cancellationToken);
      Task<Guid> EditItem(Guid id, AddItemRequest ItemRequest, CancellationToken cancellationToken);
      Task<GetItemRequest> GetItem(Guid id, CancellationToken cancellationToken);
      Task<List<GetItemRequest>> GetItems(CancellationToken cancellationToken);
}
