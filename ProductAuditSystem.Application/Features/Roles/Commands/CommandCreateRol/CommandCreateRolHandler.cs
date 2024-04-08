using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.Roles.Commands.CommandCreateRol;

internal sealed class CommandCreateRolHandler : IRequestHandler<CommandCreateRol, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IRolesRepository _rolesRepository;

    public CommandCreateRolHandler(IMapper mapper, IRolesRepository rolesRepository)
    {
        _mapper = mapper;
        _rolesRepository = rolesRepository;
    }

    public async Task<BaseCommandResponse> Handle(CommandCreateRol request, CancellationToken cancellationToken)
    {
        var validator = new CommandCreateRolValidator(_rolesRepository);
        var validationResults = await validator.ValidateAsync(request, cancellationToken);

        if (validationResults.Errors.Any())
            throw new BadRequestException("Comando Crear Rol Invalido", validationResults);

        var createRol = _mapper.Map<Domain.Rol>(request);

        await _rolesRepository.CreateAsync(createRol);

        return new BaseCommandResponse
        {
            Id = createRol.Id,
            Message = $"Se ha creado exitosamente el Rol con ID:{createRol.Id}",
            Success = true
        };
    }
}
