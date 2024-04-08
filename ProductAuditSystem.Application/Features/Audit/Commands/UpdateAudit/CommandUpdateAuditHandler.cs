using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Features.Audit.Commands.UpdateAudit;

#nullable disable

internal sealed class CommandUpdateAuditHandler : IRequestHandler<CommandUpdateAudit, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAuditRepository _auditRepository;
    private readonly IAuditUserRepository _auditUserRepository;
    private readonly IOEMsRepository _oEMsRepository;
    private readonly IAuditStatusRepository _auditStatusRepository;

    public CommandUpdateAuditHandler(IMapper mapper, IAuditRepository auditRepository,
        IAuditUserRepository auditUserRepository, IOEMsRepository oEMsRepository, IAuditStatusRepository auditStatusRepository)
    {
        _mapper = mapper;
        _auditRepository = auditRepository;
        _auditUserRepository = auditUserRepository;
        _oEMsRepository = oEMsRepository;
        _auditStatusRepository = auditStatusRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandUpdateAudit request, CancellationToken cancellationToken)
    {
        var validator = new CommandUpdateAuditValidator(_oEMsRepository, _auditRepository, _auditStatusRepository);
        var validationResults = await validator.ValidateAsync(request, cancellationToken);

        if (validationResults.Errors.Any())
            throw new BadRequestException("Comando Actualizar Auditoria Invalido", validationResults);

        var auditToUpdate = _mapper.Map<Domain.Audit>(request);

        await _auditRepository.UpdateAsync(auditToUpdate);

        var updatedAuditUsers = request.Auditores.Select(au => new AuditUser { AuditoriaID = request.Id, UsuarioID = au.Id }).ToList(); 

        await _auditUserRepository.UpdateAuditUsers(request.Id, updatedAuditUsers);

        return new BaseCommandResponse
        {
            Id = request.Id,
            Message = $"Se ha editado exitosamente la auditoria con ID:{request.Id}",
            Success = true
        };
    }
}
