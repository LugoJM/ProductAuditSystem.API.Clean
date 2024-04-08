using FluentValidation;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.SupportDepartment.Commands.UpdateSupportDeparment;

internal class CommandUpdateSupportDepartmentValidator : AbstractValidator<CommandUpdateSupportDepartment>
{
    private readonly ISupportDepartmentRepository _supportDepartmentRepository;
    public CommandUpdateSupportDepartmentValidator(ISupportDepartmentRepository supportDepartmentRepository)
    {
        _supportDepartmentRepository = supportDepartmentRepository;
        
        RuleFor(p => p.Id)
            .MustAsync(SupportDepartmentMustExist).WithMessage("El Departamento de Soporte con ID '{PropertyValue} no existe.");

        RuleFor(p => p.Department)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no puede estar vacio.")
            .MustAsync(DepartmentMustNotExist).WithMessage("El departamento de soporte '{PropertyValue}' ya existe.");
    }

    private async Task<bool> DepartmentMustNotExist(string supportDepartmentName, CancellationToken token)
    {
        var supportDepartment = await _supportDepartmentRepository.FindSupportDepartment(supportDepartmentName);
        return supportDepartment is null;
    }

    private async Task<bool> SupportDepartmentMustExist(int supportDepartmentID, CancellationToken token)
    {
        var supportDeparment = await _supportDepartmentRepository.GetByIdAsync(supportDepartmentID);
        return supportDeparment is not null;
    }
}
