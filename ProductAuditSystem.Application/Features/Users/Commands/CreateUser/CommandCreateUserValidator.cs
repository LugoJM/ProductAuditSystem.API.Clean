using FluentValidation;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.Users.Commands.CreateUser;

internal class CommandCreateUserValidator : AbstractValidator<CommandCreateUser>
{
    private readonly IRolesRepository _rolesRepository;
    private readonly IUserRepository _userRepository;
    public CommandCreateUserValidator(IRolesRepository rolesRepository, IUserRepository userRepository)
    {
        _rolesRepository = rolesRepository;
        _userRepository = userRepository;

        RuleFor(p => p.Username)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no estar vacio.")
            .MaximumLength(10).WithMessage("El campo '{PropertyName} no debe pasar los 10 caracteres.")
            .MustAsync(UsernameMustNotExist).WithMessage("El usuario '{PropertyValue}' ya se encuentra registrado.");

        RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no estar vacio.")
            .MaximumLength(50).WithMessage("El campo '{PropertyName} no debe pasar los 50 caracteres.");

        RuleFor(p => p.RolID)
            .MustAsync(RoleMustExist).WithMessage("El rol con ID '{PropertyValue}' no existe.");

        RuleFor(p => p.Correo)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no es requerido.")
            .EmailAddress().WithMessage("El correo proporcionado no tienen el formato correcto.");
    }

    private async Task<bool> UsernameMustNotExist(string username, CancellationToken token)
    {
        var user = await _userRepository.GetUser(username);
        return user is null;
    }

    private async Task<bool> RoleMustExist(int rolID, CancellationToken token)
    {
        var role = await _rolesRepository.GetByIdAsync(rolID);
        return role is not null;
    }
}
