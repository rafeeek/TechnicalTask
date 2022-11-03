using Application.GroupPermissions.Group.Commands;
using Application.GroupPermissions.GroupPermission.ViewModels;
using Application.Helpers;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupPermissions.GroupPermission.Commands
{
    public class GroupPermissionCommandsHandler : IRequestHandler<GroupPermissionAddCommand, ResponseOfQqueries<Domain.GroupPermissionsAggregate.GroupPermission>>,
                                                  IRequestHandler<GroupPermissionUpdateCommand , ResponseOfQqueries<GroupPermissionUpdateCommand>>  
    {

        #region Ctor
        private readonly TaskDbContext _context;
        private readonly IMapper _mapper;

        public GroupPermissionCommandsHandler(TaskDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        #endregion


        public async Task<ResponseOfQqueries<Domain.GroupPermissionsAggregate.GroupPermission>> Handle(GroupPermissionAddCommand request, CancellationToken cancellationToken)
        {
            var groupPermissionToBeAdded = _mapper.Map<Domain.GroupPermissionsAggregate.GroupPermission>(request);

            await _context.GroupPermissions.AddAsync(groupPermissionToBeAdded, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseOfQqueries<Domain.GroupPermissionsAggregate.GroupPermission>
            {
                Status = true,
                Data = groupPermissionToBeAdded,
                Message = "Added Successfully"
            };
        }

        public async Task<ResponseOfQqueries<GroupPermissionUpdateCommand>> Handle(GroupPermissionUpdateCommand request, CancellationToken cancellationToken)
        {
            var groupPermissionToBeUpdate = _mapper.Map<Domain.GroupPermissionsAggregate.GroupPermission>(request);
            _context.GroupPermissions.Update(groupPermissionToBeUpdate);
            _context.SaveChanges();
            return new ResponseOfQqueries<GroupPermissionUpdateCommand>
            {
                Status = true,
                Data = request,
                Message = "Update Successfully"
            };
        }
    }
}
