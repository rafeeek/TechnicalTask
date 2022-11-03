using Application.Helpers;
using AutoMapper;
using MediatR;
using Persistence;


namespace Application.GroupPermissions.Group.Commands
{
    public class GroupCommandsHandler : IRequestHandler<GroupAddCommand, ResponseOfQqueries<Domain.GroupPermissionsAggregate.Group>>
    {

        #region Ctor
        private readonly TaskDbContext _context;
        private readonly IMapper _mapper;

        public GroupCommandsHandler(TaskDbContext dbContext , IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        #endregion

        public async Task<ResponseOfQqueries<Domain.GroupPermissionsAggregate.Group>> Handle(GroupAddCommand request, CancellationToken cancellationToken)
        {
            var groupToBeAdded = _mapper.Map<Domain.GroupPermissionsAggregate.Group>(request);

            await _context.Groups.AddAsync(groupToBeAdded, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseOfQqueries<Domain.GroupPermissionsAggregate.Group>
            {
                Status = true,
                Data = groupToBeAdded,
                Message = "Added Successfully"
            };
        }
    }
}
