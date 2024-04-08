using FluentValidation;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.Roles.Commands.CommandUpdateRol;

internal class CommandUpdateRolValidator : AbstractValidator<CommandUpdateRol>
{
    private readonly IRolesRepository _rolesRepository;
    public CommandUpdateRolValidator(IRolesRepository rolesRepository)
    {
        _rolesRepository = rolesRepository;
     
        RuleFor(p => p.Id)
            .MustAsync(RoleMustExist).WithMessage("El Rol con ID '{PropertyValue} no existe.");

        RuleFor(p => p.RolNombre)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no puede estar vacio.")
            .MustAsync(RoleMustNotExist).WithMessage("El rol '{PropertyValue}' ya existe");
    }

    private async Task<bool> RoleMustNotExist(string roleName, CancellationToken token)
    {
        var rol = await _rolesRepository.FindRole(roleName);
        return rol is null;
    }

    private async Task<bool> RoleMustExist(int rolID, CancellationToken token)
    {
        var rol = await _rolesRepository.GetByIdAsync(rolID);
        return rol is not null;
    }
}
