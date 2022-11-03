using Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupPermissions.GroupPermission.Commands
{
    public class GroupPermissionAddCommand : IRequest<ResponseOfQqueries<Domain.GroupPermissionsAggregate.GroupPermission>>
    {
        public int GroupId { get; set; }
        //public Domain.GroupPermissionsAggregate.Group? Group { get; set; }
        public int PageId { get; set; }
        public bool CanView { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

    }
}
