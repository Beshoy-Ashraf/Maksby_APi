using Maksby.Contract.Product;

namespace Maksby.Services.ProductServices.Interface;

public interface IProductService
{

      Task<Guid> AddProduct(AddProductRequest ProductRequest, CancellationToken cancellationToken);
      Task<Guid> EditProduct(Guid id, AddProductRequest ProductRequest, CancellationToken cancellationToken);
      Task<GetProductRequest> GetProduct(Guid id, CancellationToken cancellationToken);
      Task<List<GetProductRequest>> GetProducts(CancellationToken cancellationToken);
}
