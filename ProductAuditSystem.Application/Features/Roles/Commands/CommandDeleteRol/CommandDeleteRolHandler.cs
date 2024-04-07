using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.Roles.Commands.CommandDeleteRol;

internal sealed class CommandDeleteRolHandler : IRequestHandler<CommandDeleteRol, BaseCommandResponse>
{
    private readonly IRolesRepository _rolesRepository;

    public CommandDeleteRolHandler(IRolesRepository rolesRepository)
    {
        _rolesRepository = rolesRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandDeleteRol request, CancellationToken cancellationToken)
    {
        var rolToDelete = await _rolesRepository.GetByIdAsync(request.Id);

        if (rolToDelete == null)
            throw new NotFoundException(nameof(rolToDelete), request.Id);

        await _rolesRepository.DeleteAsync(rolToDelete);

        return new BaseCommandResponse
        {
            Id = request.Id,
            Message = $"Se ha eliminado correctamente el Rol con ID:{request.Id}",
            Success = true
        };
    }
}
