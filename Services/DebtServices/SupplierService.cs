using Maksby.Contract.Supplier;
using Maksby.Data.Context;
using Maksby.Data.Models.Debt;
using Maksby.Services.DebtServices.Interface;
using Microsoft.EntityFrameworkCore;

namespace Maksby.Services.DebtServices;

public class SupplierService : ISupplierService
{
      private readonly AppDBContext _dbContext;
      private readonly IServiceProvider _serviceProvider;
      private readonly ILogger<SupplierService> _logger;

      public SupplierService(AppDBContext dbContext, IServiceProvider serviceProvider, ILogger<SupplierService> logger)
      {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            _logger = logger;
      }

      public async Task<Guid> AddSupplier(AddSupplierRequest addSupplierRequest, CancellationToken cancellationToken)
      {
            var supplier = new Supplier
            {
                  FirstName = addSupplierRequest.FirstName,
                  LastName = addSupplierRequest.LastName,

            };
            await _dbContext.Suppliers.AddAsync(supplier, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return supplier.Id;
      }




      public async Task<Guid> EditSupplier(Guid id, AddSupplierRequest addSupplierRequest, CancellationToken cancellationToken)
      {
            var Supplier = await _dbContext.Suppliers.SingleOrDefaultAsync(c => c.Id == id);
            if (Supplier == null)
            {
                  throw new Exception("Supplier not found");
            }

            Supplier.FirstName = addSupplierRequest.FirstName;
            Supplier.LastName = addSupplierRequest.LastName;
            Supplier.UpdatedDate = DateTime.UtcNow;

            _dbContext.Suppliers.Update(Supplier);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Supplier.Id;
      }
      public async Task<GetSupplierRequest> GetSupplier(Guid id, CancellationToken cancellationToken)
      {
            var Supplier = await _dbContext.Suppliers.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (Supplier == null)
            {
                  throw new Exception("Supplier not found");
            }

            var retrieveSupplier = new GetSupplierRequest
            {
                  Id = Supplier.Id,
                  FirstName = Supplier.FirstName,
                  LastName = Supplier.LastName,
            };


            return retrieveSupplier;
      }
      public async Task<List<GetSupplierRequest>> GetSuppliers(CancellationToken cancellationToken)
      {
            var Supplier = await _dbContext.Suppliers.ToListAsync(cancellationToken);
            if (Supplier == null)
            {
                  throw new Exception("Supplier not found");
            }
            List<GetSupplierRequest> SupplierList = new List<GetSupplierRequest>();
            foreach (var ele in Supplier)
            {
                  var retrieveSupplier = new GetSupplierRequest
                  {
                        Id = ele.Id,
                        FirstName = ele.FirstName,
                        LastName = ele.LastName,
                  };
                  SupplierList.Add(retrieveSupplier);
            }
            return SupplierList;
      }

}
