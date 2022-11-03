using Application.GroupPermissions.GroupPermission.Commands;
using Application.GroupPermissions.GroupPermission.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupPermissions.GroupPermission
{
    public class GroupPermissionMappingProfile : Profile
    {
        public GroupPermissionMappingProfile()
        {
            CreateMap<Domain.GroupPermissionsAggregate.GroupPermission, GroupPermissionAddCommand>().ReverseMap();
            CreateMap<Domain.GroupPermissionsAggregate.GroupPermission, GroupPermissionUpdateCommand>().ReverseMap();
            CreateMap<Domain.GroupPermissionsAggregate.GroupPermission, GroupPermissionVM>().ReverseMap();
        }
    }
}
