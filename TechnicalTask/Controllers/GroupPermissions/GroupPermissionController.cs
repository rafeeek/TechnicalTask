using Application.GroupPermissions.Group.Commands;
using Application.GroupPermissions.GroupPermission.Commands;
using Application.GroupPermissions.GroupPermission.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalTask.Controllers.GroupPermissions
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupPermissionController : BaseController
    {
        // POST api/<GroupController>
        [HttpPost]
        [Route("GroupPermissionAdd")]
        public async Task<IActionResult> Add([FromBody] GroupPermissionAddCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("GroupPermissionUpdate")]
        public async Task<IActionResult> Update([FromBody] GroupPermissionUpdateCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("GroupPermissionGetAll/{groupId}")]
        public async Task<IActionResult> GetAll(int groupId)
        {
            var get = new GroupPermissionGetListQuery() { GroupId = groupId };
            var result = await Mediator.Send(get);
            return Ok(result);
        }
    }
}
