using Maksby.Contract.Batch;
using Maksby.Data.Context;
using Maksby.Data.Models.batch;
using Maksby.Services.BatchServices.Interface;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Services.BatchServices;

public class BatchServices : IBatchServices
{

      private readonly AppDBContext _dbContext;
      private readonly IServiceProvider _serviceProvider;
      private readonly ILogger<BatchServices> _logger;

      public BatchServices(AppDBContext dbContext, IServiceProvider serviceProvider, ILogger<BatchServices> logger)
      {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            _logger = logger;
      }
      public async Task<Guid> AddBatch(AddBatchRequest addBatchRequest, CancellationToken cancellationToken)
      {

            var requestedItem = addBatchRequest.AddBatchItems.Select(i => i.ItemId);

            var allItems = await _dbContext.Items
                  .Where(i => requestedItem.Contains(i.Id))
                  .ToListAsync(cancellationToken);

            var items = allItems.Where(i => addBatchRequest.AddBatchItems
                                .Any(x => x.ItemId == i.Id && x.ItemQuantity <= i.QuantityPerKilo)

            ).ToList();

            var batchProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == addBatchRequest.ProductId, cancellationToken) ?? throw new KeyNotFoundException($"product with ID{addBatchRequest.ProductId} not found");

            if (items.Count != addBatchRequest.AddBatchItems.Count) throw new Exception("items Not Found");

            var batch = new Batch
            {
                  BatchStatus = addBatchRequest.BatchStatus,
                  ProductQuantity = addBatchRequest.ProductQuantity,
                  Product = batchProduct,
                  CreatedDate = DateTime.UtcNow

            };


            var newBatchItems = new List<BatchItem>();
            foreach (var ele in items)
            {
                  var currentItem = addBatchRequest.AddBatchItems.First(x => x.ItemId == ele.Id);
                  ele.QuantityPerKilo -= currentItem.ItemQuantity;
                  var newBatchItem = new BatchItem
                  {
                        Id = Guid.NewGuid(),
                        ItemQuantityPerKilo = ele.QuantityPerKilo,
                        Batch = batch,
                        ModifyDate = DateTime.UtcNow,
                        Item = ele
                  };
                  newBatchItems.Add(newBatchItem);
            }
            batch.BatchItems = newBatchItems;
            batchProduct.QuantityPerKilo += addBatchRequest.ProductQuantity;

            await _dbContext.Batches.AddAsync(batch, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return batch.Id;
      }
      public async Task<Guid> EditBatch(Guid id, AddBatchRequest addBatchRequest, CancellationToken cancellationToken)
      {
            var batch = await _dbContext.Batches
                  .Include(p => p.Product)
                .Include(bi => bi.BatchItems)
                .ThenInclude(i => i.Item)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken) ?? throw new KeyNotFoundException($"Invoice with ID {id} was not found.");

            var requestedItem = addBatchRequest.AddBatchItems.Select(i => i.ItemId);

            var allItems = await _dbContext.Items
                  .Where(i => requestedItem.Contains(i.Id))
                  .ToListAsync(cancellationToken);

            var items = allItems.Where(i => addBatchRequest.AddBatchItems
                                .Any(x => x.ItemId == i.Id && x.ItemQuantity <= i.QuantityPerKilo)

            ).ToList();

            foreach (var ele in batch.BatchItems)
            {
                  var item = await _dbContext.Items.FirstAsync(i => i.Id == ele.Item.Id);
                  item.QuantityPerKilo += ele.ItemQuantityPerKilo;

            }
            var oldProduct = await _dbContext.Products.FirstAsync(p => p.Id == batch.Product.Id, cancellationToken) ?? throw new KeyNotFoundException($"product with ID{batch.Product.Id} not found");
            oldProduct.QuantityPerKilo -= batch.ProductQuantity;

            var batchProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == addBatchRequest.ProductId, cancellationToken) ?? throw new KeyNotFoundException($"product with ID{addBatchRequest.ProductId} not found");
            batchProduct.QuantityPerKilo += addBatchRequest.ProductQuantity;
            batch.ProductQuantity = addBatchRequest.ProductQuantity;

            batch.UpdatedDate = DateTime.UtcNow;
            batch.BatchStatus = addBatchRequest.BatchStatus;
            batch.Product = batchProduct;

            var newBatchItems = new List<BatchItem>();
            foreach (var ele in items)
            {
                  var currentItem = addBatchRequest.AddBatchItems.First(x => x.ItemId == ele.Id);
                  ele.QuantityPerKilo -= currentItem.ItemQuantity;
                  var newBatchItem = new BatchItem
                  {
                        Id = Guid.NewGuid(),
                        ItemQuantityPerKilo = ele.QuantityPerKilo,
                        Batch = batch,
                        ModifyDate = DateTime.UtcNow,
                        Item = ele
                  };
                  newBatchItems.Add(newBatchItem);
            }
            batch.BatchItems = newBatchItems;


            _dbContext.Batches.Update(batch);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return batch.Id;

      }

      public async Task<GetBatchRequest> GetBatch(Guid id, CancellationToken cancellationToken)
      {
            var batch = await _dbContext.Batches
               .Include(p => p.Product)
             .Include(bi => bi.BatchItems)
             .ThenInclude(i => i.Item)
             .FirstOrDefaultAsync(x => x.Id == id, cancellationToken) ?? throw new KeyNotFoundException($"Invoice with ID {id} was not found.");

            var response = new GetBatchRequest
            {
                  Id = batch.Id,
                  ProductId = batch.Product.Id,
                  ProductName = batch.Product.Name,
                  ProductQuantity = batch.ProductQuantity,
                  BatchStatus = batch.BatchStatus,
                  BatchItems = [.. batch.BatchItems.Select(i =>new BatchItems{
                        ItemId =i.Id,
                        ItemQuantity =i.ItemQuantityPerKilo,
                        ItemName = i.Item.Name,
                        ModifyDate = i.ModifyDate
                  })]
            };
            return response;
      }
      public async Task<List<GetBatchRequest>> GetBatches(CancellationToken cancellationToken)
      {
            var batches = await _dbContext.Batches
               .Include(p => p.Product)
             .Include(bi => bi.BatchItems)
             .ThenInclude(i => i.Item)
             .Select(
                        i => new GetBatchRequest
                        {
                              Id = i.Id,
                              ProductId = i.Product.Id,
                              ProductName = i.Product.Name,
                              ProductQuantity = i.ProductQuantity,
                              BatchStatus = i.BatchStatus,
                              BatchItems = i.BatchItems.Select(x => new BatchItems
                              {
                                    ItemId = x.Id,
                                    ItemQuantity = x.ItemQuantityPerKilo,
                                    ItemName = x.Item.Name,
                                    ModifyDate = x.ModifyDate
                              }).ToList()
                        }).ToListAsync(cancellationToken);
            return batches;
      }

      public async Task<Guid> ChangeBatchStatus(Guid id, BatchStatus status, CancellationToken cancellationToken)
      {
            var batch = await _dbContext.Batches
                  .FirstOrDefaultAsync(x => x.Id == id, cancellationToken) ?? throw new KeyNotFoundException($"Batch with ID {id} was not found.");

            batch.BatchStatus = status;
            batch.UpdatedDate = DateTime.UtcNow;

            _dbContext.Batches.Update(batch);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return batch.Id;
      }



}
