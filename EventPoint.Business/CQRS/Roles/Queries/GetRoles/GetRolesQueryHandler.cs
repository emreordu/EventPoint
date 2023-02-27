using AutoMapper;
using EventPoint.Business.Helpers.Models;
using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.Roles.Queries.GetRoles
{
    public class GetRolesQueryHandler : IQueryHandler<GetRolesQuery, List<RoleViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<Role> roleRepository;
        public GetRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            roleRepository = _unitOfWork.GetRepository<Role>();
        }

        public async Task<List<RoleViewModel>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await roleRepository.GetAllAsync(null, request.PageSize, request.PageNumber);
            if (roles.Any())
            {
                var mapRoles = _mapper.Map<List<RoleViewModel>>(roles);
                return mapRoles;
            }
            throw new InvalidOperationException();
        }
    }
}