using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;

namespace ProductAuditSystem.Application.Features.Roles.Queries.GetRol;

internal sealed class GetRolQueryHandler : IRequestHandler<GetRolQuery, GetRolDTO>
{
    private readonly IMapper _mapper;
    private readonly IRolesRepository _rolesRepository;

    public GetRolQueryHandler(IMapper mapper, IRolesRepository rolesRepository)
    {
        _mapper = mapper;
        _rolesRepository = rolesRepository;
    }

    public async Task<GetRolDTO> Handle(GetRolQuery request, CancellationToken cancellationToken)
    {
        var rol = await _rolesRepository.GetByIdAsync(request.Id);

        if (rol == null)
            throw new NotFoundException(nameof(rol), request.Id);

        var data = _mapper.Map<GetRolDTO>(rol);

        return data;
    }
}
