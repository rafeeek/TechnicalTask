using Application.GroupPermissions.Group.Commands;
using Application.GroupPermissions.Group.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechnicalTask.Controllers.GroupPermissions
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : BaseController
    {

        [HttpGet("GroupGetList")]
        public async Task<IActionResult> GroupGetList()
        {
            var obj = new GroupGetListQuery();
            var result = await Mediator.Send(obj);
            return Ok(result);
        }

        [HttpPost("GroupById")]
        public async Task<IActionResult> GroupById([FromBody] GroupGetByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GroupAdd([FromBody] GroupAddCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

    }
}
