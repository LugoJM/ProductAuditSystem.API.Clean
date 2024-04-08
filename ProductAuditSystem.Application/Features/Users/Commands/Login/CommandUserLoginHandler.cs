using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Infrastructure.ActiveDirectory;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;

namespace ProductAuditSystem.Application.Features.Users.Commands.Login;

internal sealed class CommandUserLoginHandler : IRequestHandler<CommandUserLogin, UserInfoDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly IActiveDirectory _activeDirectory;

    public CommandUserLoginHandler(IUserRepository userRepository, IActiveDirectory activeDirectory)
    {
        _userRepository = userRepository;
        _activeDirectory = activeDirectory;
    }
    public async Task<UserInfoDTO> Handle(CommandUserLogin request, CancellationToken cancellationToken)
    {
        var validator = new CommandUserLoginValidator(_userRepository);
        var validationResults = await validator.ValidateAsync(request, cancellationToken);

        if (validationResults.Errors.Any())
            throw new BadRequestException("Comando Iniciar Sesion Invalido", validationResults);

        var dbUser = await _userRepository.UserInDB(request);

        if (!_activeDirectory.login(request)) 
            throw new BadRequestException("Usuario de windows no valido! Verificar las credenciales.");

        return new UserInfoDTO
        {
            Name = dbUser.Nombre,
            Username = dbUser.Username,
            Email = dbUser.Correo,
            Roles = new List<string>()
            {
                dbUser.Rol.RolNombre
            },
        };
    }
}
