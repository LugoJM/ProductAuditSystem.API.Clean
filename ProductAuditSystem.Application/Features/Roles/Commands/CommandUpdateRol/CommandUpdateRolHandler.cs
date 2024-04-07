using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.Roles.Commands.CommandUpdateRol;

internal sealed class CommandUpdateRolHandler : IRequestHandler<CommandUpdateRol, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IRolesRepository _rolesRepository;

    public CommandUpdateRolHandler(IMapper mapper, IRolesRepository rolesRepository)
    {
        _mapper = mapper;
        _rolesRepository = rolesRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandUpdateRol request, CancellationToken cancellationToken)
    {
        var rolToUpdate = _mapper.Map<Domain.Rol>(request);

        await _rolesRepository.UpdateAsync(rolToUpdate);

        return new BaseCommandResponse
        {
            Id = rolToUpdate.Id,
            Message = $"Se ha actualizado correctamente el Rol con ID:{rolToUpdate.Id}",
            Success = true
        };
    }
}
