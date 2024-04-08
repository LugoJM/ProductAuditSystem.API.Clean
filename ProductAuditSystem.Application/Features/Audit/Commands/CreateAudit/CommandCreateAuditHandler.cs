using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;
using ProductAuditSystem.Domain;

#nullable disable

namespace ProductAuditSystem.Application.Features.Audit.Commands.CreateAudit;

internal sealed class CommandCreateAuditHandler : IRequestHandler<CommandCreateAudit, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAuditRepository _auditRepository;
    private readonly IAuditUserRepository _auditUserRepository;

    public CommandCreateAuditHandler(IMapper mapper, IAuditRepository auditRepository,
        IAuditUserRepository auditUserRepository)
    {
        _mapper = mapper;
        _auditRepository = auditRepository;
        _auditUserRepository = auditUserRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandCreateAudit request, CancellationToken cancellationToken)
    {
        var validator = new CommandCreateAuditValidator();
        var validatorResults = await validator.ValidateAsync(request, cancellationToken);

        if (validatorResults.Errors.Any())
            throw new BadRequestException("Comando Crear Auditoria Invalido", validatorResults);

        var auditToCreate = _mapper.Map<Domain.Audit>(request);

        await _auditRepository.CreateAsync(auditToCreate);

        var auditUsers = request.Auditores.Select(a => new AuditUser { AuditoriaID = auditToCreate.Id, UsuarioID = a.AuditorUserID }).ToList();

        await _auditUserRepository.AddAuditUsers(auditUsers);

        return new BaseCommandResponse
        {
            Id = auditToCreate.Id,
            Message = $"Se ha creado exitosamente la auditoria con ID:{auditToCreate.Id}",
            Success = true
        };
    }
}
