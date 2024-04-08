using FluentValidation;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.AuditStatus.Commands.CommandCreateAuditStatus;

internal class CommandCreateAuditStatusValidator : AbstractValidator<CommandCreateAuditStatus>
{
    private readonly IAuditStatusRepository _auditStatusRepository;
    public CommandCreateAuditStatusValidator(IAuditStatusRepository auditStatusRepository)
    {
        _auditStatusRepository = auditStatusRepository;

        RuleFor(p => p.Status)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no puede estar vacio.")
            .MustAsync(StatusMustNotExist).WithMessage("El status '{PropertyValue}' ya existe.");
    }

    private async Task<bool> StatusMustNotExist(string status, CancellationToken token)
    {
        var auditStatus = await _auditStatusRepository.FindStatus(status);
        return auditStatus is null;
    }
}
