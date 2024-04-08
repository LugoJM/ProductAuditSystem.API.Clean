using FluentValidation;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.AuditStatus.Commands.CommandUpdateAuditStatus;

internal class CommandUpdateAuditStatusValidator : AbstractValidator<CommandUpdateAuditStatus>
{
    private readonly IAuditStatusRepository _auditStatusRepository;
    public CommandUpdateAuditStatusValidator(IAuditStatusRepository auditStatusRepository)
    {
        _auditStatusRepository = auditStatusRepository;

        RuleFor(p => p.Id)
            .MustAsync(AuditStatusMustExist).WithMessage("El status con ID '{PropertyValue}' no existe");

        RuleFor(p => p.Status)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no puede estar vacio.")
            .MustAsync(StatusMustNotExist).WithMessage("El status '{PropertyValue}' ya existe.");
    }

    private async Task<bool> AuditStatusMustExist(int auditStatusID, CancellationToken token)
    {
        var auditStatus = await _auditStatusRepository.GetByIdAsync(auditStatusID);
        return auditStatus is not null;
    }

    private async Task<bool> StatusMustNotExist(string status, CancellationToken token)
    {
        var auditStatus = await _auditStatusRepository.FindStatus(status);
        return auditStatus is null;
    }
}
