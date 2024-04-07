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

    public CommandUpdateAuditHandler(IMapper mapper, IAuditRepository auditRepository,
        IAuditUserRepository auditUserRepository)
    {
        _mapper = mapper;
        _auditRepository = auditRepository;
        _auditUserRepository = auditUserRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandUpdateAudit request, CancellationToken cancellationToken)
    {
        var auditToUpdate = _mapper.Map<Domain.Audit>(request);

        await _auditRepository.UpdateAsync(auditToUpdate);

        if (request.Auditores == null || request.Auditores.Count == 0)
        {
            throw new BadRequestException("Una auditoria debe tener minimo 1 auditor");
        }

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
