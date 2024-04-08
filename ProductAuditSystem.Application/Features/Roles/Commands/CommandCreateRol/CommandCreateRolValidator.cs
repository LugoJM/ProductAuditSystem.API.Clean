using FluentValidation;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.Roles.Commands.CommandCreateRol;

internal class CommandCreateRolValidator : AbstractValidator<CommandCreateRol>
{
    private readonly IRolesRepository _rolesRepository;
    public CommandCreateRolValidator(IRolesRepository rolesRepository)
    {
        _rolesRepository = rolesRepository;

        RuleFor(p => p.RolNombre)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no puede estar vacio.")
            .MaximumLength(25).WithMessage("El campo '{PropertyName}' no puede exceder los 25 caracteres.")
            .MustAsync(RolMustNotExist).WithMessage("El Rol '{PropertyValue}' ya existe.");
    }

    private async Task<bool> RolMustNotExist(string rolName, CancellationToken token)
    {
        var role = await _rolesRepository.FindRole(rolName);
        return role is null;
    }
}
