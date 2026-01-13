
using Maksby.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ProductController : ControllerBase
{

      [HttpPut("{id:Guid}")]
      public async Task<ActionResult<Guid>> EditProduct([FromRoute] Guid id, [FromBody] AddProductRequest addProductRequest, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.EditProduct(id, addProductRequest, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't Edit Product");
            }

      }


}
