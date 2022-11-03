using Application.GroupPermissions.Group.ViewModels;
using Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupPermissions.Group.Queries
{
    public class GroupGetByIdQuery : IRequest<ResponseOfQqueries<GroupVM>>
    {
        public int Id { get; set; }
    }
}
