using FluentValidation;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Features.Question.Classes;

namespace ProductAuditSystem.Application.Features.Question.Commands.CreateQuestion;

internal class CommandCreateQuestionValidator : AbstractValidator<CommandCreateQuestion>
{
    private readonly ISupportDepartmentRepository _supportDepartmentRepository;
    private readonly IAuditRepository _auditRepository;
    public CommandCreateQuestionValidator(ISupportDepartmentRepository supportDepartmentRepository, IAuditRepository auditRepository)
    {
        _supportDepartmentRepository = supportDepartmentRepository;
        _auditRepository = auditRepository;

        RuleFor(p => p.Contenido)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no puede estar vacio.")
            .MaximumLength(50).WithMessage("El campo '{PropertyName}' no puede sobrepasar 50 caracteres.");

        RuleFor(p => p.SoporteID)
            .MustAsync(SupportDepartmentMustExist).WithMessage("El departamento de soporte con ID '{PropertyValue}' no existe.");

        RuleFor(p => p.Comentarios)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no puede estar vacio.")
            .MaximumLength(30).WithMessage("El campo '{PropertyName}' no puede sobrepasar 30 caracteres.");

        RuleFor(p => p.ComentariosPuntos)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no puede estar vacia.")
            .MaximumLength(50).WithMessage("El campo '{PropertyName}' no puede sobrepasar 50 caracteres.");

        RuleFor(p => p.ReferenceDocuments)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no puede estar vacia.")
            .MaximumLength(50).WithMessage("El campo '{PropertyName}' no puede sobrepasar 50 caracteres");

        RuleFor(p => p.EvaluationPoints.Points)
            .Must(EvaluationPointsMustBeSameAsTemplate).WithMessage("El campo '{PropertyName}' debe contener al menos 1 punto.");

        RuleFor(p => p.AuditId)
            .MustAsync(AuditMustExist).WithMessage("La auditoria con ID '{PropertyValue} no existe.");
    }

    private async Task<bool> AuditMustExist(int audiID, CancellationToken token)
    {
        var audit = await _auditRepository.GetAudit(audiID);
        return audit is not null;
    }

    private bool EvaluationPointsMustBeSameAsTemplate(List<QuestionEP> evaluationPoints) => evaluationPoints.Count > 0;
    
    private async Task<bool> SupportDepartmentMustExist(int supportDepartmentID, CancellationToken token)
    {
        var supportDepartment = await _supportDepartmentRepository.GetByIdAsync(supportDepartmentID);
        return supportDepartment is not null;
    }
}
