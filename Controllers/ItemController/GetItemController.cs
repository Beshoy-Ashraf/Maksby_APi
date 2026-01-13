using Maksby.Contract.Item;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



public partial class ItemController : ControllerBase
{

      [HttpGet("{id:Guid}")]
      public async Task<ActionResult<GetItemRequest>> GetItem([FromRoute] Guid id, CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetItem(id, cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't get Item");
            }
      }
      [HttpGet]
      public async Task<ActionResult<List<GetItemRequest>>> GetItems(CancellationToken cancellationToken)
      {
            try
            {
                  return await _services.GetItems(cancellationToken);
            }
            catch (Exception)
            {
                  return BadRequest("Can't get Items");
            }
      }


}
