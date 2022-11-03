using Application.GroupPermissions.Group.ViewModels;
using Application.Helpers;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupPermissions.Group.Queries
{
    public class GroupQueriesHandler : IRequestHandler<GroupGetByIdQuery, ResponseOfQqueries<GroupVM>>,
                                       IRequestHandler<GroupGetListQuery, ResponseOfQqueries<List<GroupVM>>>
    {

        #region Ctor
        private readonly TaskDbContext _context;
        private readonly IMapper _mapper;

        public GroupQueriesHandler(TaskDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        #endregion


        public async Task<ResponseOfQqueries<GroupVM>> Handle(GroupGetByIdQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Groups.Find(request.Id);
            var dataVm = _mapper.Map<GroupVM>(data);
            return new ResponseOfQqueries<GroupVM>
            {
                Status = true,
                Data = dataVm,
                Message = ""
            };
        }

        public async Task<ResponseOfQqueries<List<GroupVM>>> Handle(GroupGetListQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Groups.ToListAsync();
            var dataVm =  _mapper.Map<List<GroupVM>>(data);
            return new ResponseOfQqueries<List<GroupVM>>
            {
                Status = true,
                Data = dataVm,
                Message = ""
            };
        }
    }
}
