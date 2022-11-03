using Application.GroupPermissions.Group.ViewModels;
using Application.Helpers;
using MediatR;


namespace Application.GroupPermissions.Group.Queries
{
    public class GroupGetListQuery : IRequest<ResponseOfQqueries<List<GroupVM>>>
    {

    }
}
