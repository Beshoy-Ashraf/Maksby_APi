
using Maksby.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ProductController : ControllerBase
{

      [HttpPost]
      public async Task<ActionResult<Guid>> AddProduct([FromBody] AddProductRequest addProductRequest, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.AddProduct(addProductRequest, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't Add Product");
            }
      }


}
