using FluentValidation;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.SupportDepartment.Commands.CreateSupportDepartment;

internal class CommandCreateSupportDepartmentValidator : AbstractValidator<CommandCreateSupportDepartment>
{
    private readonly ISupportDepartmentRepository _supportDepartmentRepository;
    public CommandCreateSupportDepartmentValidator(ISupportDepartmentRepository supportDepartmentRepository)
    {
        _supportDepartmentRepository = supportDepartmentRepository;

        RuleFor(p => p.Department)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no puede estar vacio.")
            .MustAsync(DepartmentMustNotExist).WithMessage("El departamento con nombre '{PropertyValue}' ya existe.");
    }

    private async Task<bool> DepartmentMustNotExist(string supportDepartmentName, CancellationToken token)
    {
        var supportDepartment = await _supportDepartmentRepository.FindSupportDepartment(supportDepartmentName);
        return supportDepartment is null;
    }
}
