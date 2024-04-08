using FluentValidation;
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.Application.Features.Audit.Commands.CreateAudit;

internal class CommandCreateAuditValidator : AbstractValidator<CommandCreateAudit>
{
    public CommandCreateAuditValidator()
    {
        RuleFor<List<UserID>>(p => p.Auditores)
            .NotNull().WithMessage("El campo '{PropertyName}' no puede ser nulo.")
            .Must(AuditorsListMustHaveOne()).WithMessage("El campo '{PropertyName}' debe contener al menos 1 auditor.");

        RuleFor(p => p.AuditoriaOEM)
            .NotNull().WithMessage("El campo '{PropertyName}' no puede ser nulo.");

        RuleFor(p => p.AuditoriaStatus)
            .NotNull().WithMessage("El campo '{PropertyName}' no puede ser nulo.");

        RuleFor(p => p.Programa)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no puede estar vacio.")
            .MaximumLength(50).WithMessage("El campo '{PropertyName}' no debe pasar 50 caracteres.");

        RuleFor(p => p.Comentarios)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no puede estar vacio.")
            .MaximumLength(100).WithMessage("El campo '{PropertyName}' no debe pasar 50 caracteres.");
    }

    private static Func<List<UserID>, bool> AuditorsListMustHaveOne() => list => list.Count > 0;
}