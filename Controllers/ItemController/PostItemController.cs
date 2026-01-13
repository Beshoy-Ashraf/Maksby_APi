
using Maksby.Contract.Supplier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ItemController : ControllerBase
{

      [HttpPost]
      public async Task<ActionResult<Guid>> AddItem([FromBody] AddItemRequest addItemRequest, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.AddItem(addItemRequest, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't Add Item");
            }
      }


}
