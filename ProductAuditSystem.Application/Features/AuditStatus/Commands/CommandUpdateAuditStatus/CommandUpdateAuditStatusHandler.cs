
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.AuditStatus.Commands.CommandUpdateAuditStatus;

public sealed class CommandUpdateAuditStatusHandler : IRequestHandler<CommandUpdateAuditStatus, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAuditStatusRepository _auditStatusRepository;

    public CommandUpdateAuditStatusHandler(IMapper mapper, IAuditStatusRepository auditStatusRepository)
    {
        _mapper = mapper;
        _auditStatusRepository = auditStatusRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandUpdateAuditStatus request, CancellationToken cancellationToken)
    {
        var validator = new CommandUpdateAuditStatusValidator(_auditStatusRepository);
        var validationResults = await validator.ValidateAsync(request, cancellationToken);

        if (validationResults.Errors.Any())
            throw new BadRequestException("Comando Actualizar Status Auditoria Invalido", validationResults);

        var auditStatusToUpdate = await _auditStatusRepository.GetByIdAsync(request.Id);

        _mapper.Map(request, auditStatusToUpdate);

        await _auditStatusRepository.UpdateAsync(auditStatusToUpdate);

        return new BaseCommandResponse
        {
            Id = request.Id,
            Message = $"Se ha actualizado correctamente el Audit Status con ID:{request.Id}",
            Success = true
        };
    }
}
