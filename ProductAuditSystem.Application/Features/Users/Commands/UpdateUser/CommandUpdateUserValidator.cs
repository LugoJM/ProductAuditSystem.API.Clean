using FluentValidation;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.Users.Commands.UpdateUser;

internal class CommandUpdateUserValidator : AbstractValidator<CommandUpdateUser>
{
    private readonly IRolesRepository _rolesRepository;
    private readonly IUserRepository _userRepository;

    public CommandUpdateUserValidator(IRolesRepository rolesRepository, IUserRepository userRepository)
    {
        _rolesRepository = rolesRepository;
        _userRepository = userRepository;

        RuleFor(p => p.Id)
            .MustAsync(UserMustExist).WithMessage("El usuario con ID '{PropertyValue}' no existe.");

        RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no estar vacio.")
            .MaximumLength(50).WithMessage("El campo '{PropertyName} no debe pasar los 50 caracteres.");

        RuleFor(p => p.RolID)
            .MustAsync(RoleMustExist).WithMessage("El rol con ID '{PropertyValue}' no existe.");

        RuleFor(p => p.Correo)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no es requerido.")
            .EmailAddress().WithMessage("El correo proporcionado no tienen el formato correcto.");
    }

    private async Task<bool> UserMustExist(int userID, CancellationToken token)
    {
        var user = await _userRepository.GetByIdAsync(userID);
        return user is not null;
    }

    private async Task<bool> RoleMustExist(int roleID, CancellationToken token)
    {
        var role = await _rolesRepository.GetByIdAsync(roleID);
        return role is not null;
    }
}
