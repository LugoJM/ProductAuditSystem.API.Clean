using FluentValidation;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.Users.Commands.Login;

internal class CommandUserLoginValidator : AbstractValidator<CommandUserLogin>
{
    private readonly IUserRepository _userRepository;
    public CommandUserLoginValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(p => p.Usuario)
            .NotEmpty().WithMessage("El campo '{PropertyName}' es un campo requerido.")
            .MustAsync(UserMostExist).WithMessage("El usuario '{PropertyValue}' no existe.");

        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("El campo '{PropertyName}' es un campo requerido.");

    }

    private async Task<bool> UserMostExist(string username, CancellationToken token)
    {
        var user = await _userRepository.GetUser(username);
        return user is not null;
    }
}
