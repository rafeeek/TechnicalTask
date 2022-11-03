using Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupPermissions.Group.Commands
{
    public class GroupAddCommand : IRequest<ResponseOfQqueries<Domain.GroupPermissionsAggregate.Group>>
    {
        public string? ArabicName { get; set; }
        public string? EnglishName { get; set; }
    }
}
