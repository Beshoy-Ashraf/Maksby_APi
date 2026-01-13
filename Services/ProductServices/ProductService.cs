using Maksby.Contract.Product;
using Maksby.Data.Context;
using Maksby.Data.Models.Income;
using Maksby.Services.ProductServices.Interface;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Services.ProductServices;

public class ProductService : IProductService
{
      private readonly AppDBContext _dbContext;
      private readonly IServiceProvider _serviceProvider;
      private readonly ILogger<ProductService> _logger;

      public ProductService(AppDBContext dbContext, IServiceProvider serviceProvider, ILogger<ProductService> logger)
      {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            _logger = logger;
      }
      public async Task<Guid> AddProduct(AddProductRequest addProductRequest, CancellationToken cancellationToken)
      {
            var Product = new Product
            {
                  Name = addProductRequest.Name,
                  QuantityPerKilo = addProductRequest.QuantityPerKilo,
                  PricePerKilo = addProductRequest.PricePerKilo,
                  Description = addProductRequest.Description,
                  UpdatedDate = DateTime.UtcNow,
                  DeletedDate = DateTime.UtcNow,

            };
            await _dbContext.Products.AddAsync(Product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Product.Id;

      }
      public async Task<Guid> EditProduct(Guid id, AddProductRequest addProductRequest, CancellationToken cancellationToken)
      {
            var Product = await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (Product == null)
            {
                  throw new Exception("Product not found");
            }

            Product.Name = addProductRequest.Name;
            Product.QuantityPerKilo = addProductRequest.QuantityPerKilo;
            Product.PricePerKilo = addProductRequest.PricePerKilo;
            Product.Description = addProductRequest.Description;
            Product.UpdatedDate = DateTime.UtcNow;

            _dbContext.Products.Update(Product);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Product.Id;
      }
      public async Task<GetProductRequest> GetProduct(Guid id, CancellationToken cancellationToken)
      {
            var Product = await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (Product == null)
            {
                  throw new Exception("Product not found");
            }

            var retrieveProduct = new GetProductRequest
            {
                  Id = Product.Id,
                  Name = Product.Name,
                  Description = Product.Description,
                  PricePerKilo = Product.PricePerKilo,
                  QuantityPerKilo = Product.QuantityPerKilo
            };


            return retrieveProduct;
      }
      public async Task<List<GetProductRequest>> GetProducts(CancellationToken cancellationToken)
      {
            var product = await _dbContext.Products.ToListAsync(cancellationToken);
            if (product == null)
            {
                  throw new Exception("Product not found");
            }
            List<GetProductRequest> ProductList = new List<GetProductRequest>();
            foreach (var ele in product)
            {
                  var retrieveProduct = new GetProductRequest
                  {
                        Id = ele.Id,
                        Name = ele.Name,
                        Description = ele.Description,
                        PricePerKilo = ele.PricePerKilo,
                        QuantityPerKilo = ele.QuantityPerKilo
                  };
                  ProductList.Add(retrieveProduct);
            }
            return ProductList;
      }
}
