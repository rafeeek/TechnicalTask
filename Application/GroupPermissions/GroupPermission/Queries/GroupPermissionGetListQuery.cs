using Application.GroupPermissions.GroupPermission.ViewModels;
using Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupPermissions.GroupPermission.Queries
{
    public class GroupPermissionGetListQuery : IRequest<ResponseOfQqueries<List<GroupPermissionVM>>>
    {
        public int GroupId { get; set; }
    }
}
