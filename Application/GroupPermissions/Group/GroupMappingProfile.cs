using Application.GroupPermissions.Group.Commands;
using Application.GroupPermissions.Group.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupPermissions.Group
{
    public class GroupMappingProfile : Profile
    {
        public GroupMappingProfile()
        {
            CreateMap<Domain.GroupPermissionsAggregate.Group, GroupAddCommand>().ReverseMap();
            CreateMap<GroupVM, Domain.GroupPermissionsAggregate.Group>().ReverseMap();
        }
    }
}
