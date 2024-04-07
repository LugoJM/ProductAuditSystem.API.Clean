using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.Roles.Queries.GetRoles;

internal sealed class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<GetRolDTO>>
{
    private readonly IMapper _mapper;
    private readonly IRolesRepository _rolesRepository;

    public GetRolesQueryHandler(IMapper mapper, IRolesRepository rolesRepository)
    {
        _mapper = mapper;
        _rolesRepository = rolesRepository;
    }
    public async Task<List<GetRolDTO>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await _rolesRepository.GetAsync();

        var data = _mapper.Map<List<GetRolDTO>>(roles);

        return data;
    }
}
