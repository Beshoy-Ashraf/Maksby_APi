using Maksby.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ProductController : ControllerBase
{

      [HttpGet("{id:Guid}")]
      public async Task<ActionResult<GetProductRequest>> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetProduct(id, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't get Product");
            }
      }
      [HttpGet]
      public async Task<ActionResult<List<GetProductRequest>>> GetProducts(CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetProducts(cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't get Products");
            }
      }


}
