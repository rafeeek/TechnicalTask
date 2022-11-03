using Application.GroupPermissions.Group.Queries;
using Application.GroupPermissions.Pages.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalTask.Controllers.GroupPermissions
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : BaseController
    {
        [HttpGet("PagesGetList")]
        public async Task<IActionResult> GroupGetList()
        {
            //using empty class for Handler get all to paginition in future; 
            var obj = new PagesGetListQuery();
            var result = await Mediator.Send(obj);
            return Ok(result);
        }
    }
}
