using FluentValidation;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.Audit.Commands.UpdateAudit;

internal class CommandUpdateAuditValidator : AbstractValidator<CommandUpdateAudit>
{
    private readonly IOEMsRepository _oEMsRepository;
    private readonly IAuditRepository _auditRepository;
    private readonly IAuditStatusRepository _auditStatusRepository;

    public CommandUpdateAuditValidator(IOEMsRepository oEMsRepository, IAuditRepository auditRepository,
        IAuditStatusRepository auditStatusRepository)
    {
        _oEMsRepository = oEMsRepository;
        _auditRepository = auditRepository;
        _auditStatusRepository = auditStatusRepository;

        RuleFor(p => p.Id)
            .MustAsync(AuditMustExist).WithMessage("La auditoria con ID '{PropertyValue}' no existe.");

        RuleFor(p => p.Auditores)
           .NotNull().WithMessage("El campo '{PropertyName}' no puede ser nulo.")
           .Must(c => c.Count > 0).WithMessage("El campo '{PropertyName}' debe contener al menos 1 auditor.");

        RuleFor(q => q.OEM.Id)
            .NotNull().WithMessage("El campo: '{PropertyName}' no puede ser nulo")
            .MustAsync(OEMMustExist).WithMessage("El OEM con Id '{PropertyValue}' no existe.");

        RuleFor(p => p.Programa)
            .NotEmpty().WithMessage("El cam[o '{PropertyName}' no puede estar vacio.")
            .MaximumLength(50).WithMessage("El campo '{PropertyName}' no debe pasar 50 caracteres.");

        RuleFor(p => p.Comentarios)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no puede estar vacio.")
            .MaximumLength(100).WithMessage("El campo '{PropertyName}' no debe pasar 50 caracteres.");

        RuleFor(q => q.Status.Id)
            .NotNull().WithMessage("El campo '{PropertyName}' no puede ser nulo.")
            .MustAsync(AuditStatusMustExist).WithMessage("El status con Id '{PropertyValue}' no existe.");
    }

    private async Task<bool> AuditStatusMustExist(int auditStatusID, CancellationToken token)
    {
        var auditStatus = await _auditStatusRepository.GetByIdAsync(auditStatusID);
        return auditStatus is null;
    }

    private async Task<bool> AuditMustExist(int auditID, CancellationToken token)
    {
        var audit = await _auditRepository.GetByIdAsync(auditID);
        return audit is null;
    }

    private async Task<bool> OEMMustExist(int oemID, CancellationToken token)
    {
        var oem = await _oEMsRepository.GetByIdAsync(oemID);
        return oem is null;
    }
}
