
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.AuditStatus.Commands.CommandDeleteAuditStatus;

public sealed class CommandDeleteAuditStatusHandler : IRequestHandler<CommandDeleteAuditStatus, BaseCommandResponse>
{
    private readonly IAuditStatusRepository _auditStatusRepository;

    public CommandDeleteAuditStatusHandler(IAuditStatusRepository auditStatusRepository)
    {
        _auditStatusRepository = auditStatusRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandDeleteAuditStatus request, CancellationToken cancellationToken)
    {
        var auditStatusToDelete = await _auditStatusRepository.GetByIdAsync(request.Id);

        if (auditStatusToDelete == null)
            throw new NotFoundException(nameof(auditStatusToDelete), request.Id);

        await _auditStatusRepository.DeleteAsync(auditStatusToDelete);

        return new BaseCommandResponse
        {
            Id = request.Id,
            Message = $"Se ha eliminado correctamente el Audit Status con ID:{request.Id}",
            Success = true
        };
    }
}
