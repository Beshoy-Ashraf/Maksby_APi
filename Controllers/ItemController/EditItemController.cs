
using Maksby.Contract.Supplier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ItemController : ControllerBase
{

      [HttpPut("{id:Guid}")]
      public async Task<ActionResult<Guid>> EditItem([FromRoute] Guid id, [FromBody] AddItemRequest addItemRequest, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.EditItem(id, addItemRequest, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't Edit Item");
            }

      }


}
