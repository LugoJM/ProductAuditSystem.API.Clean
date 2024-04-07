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
        if (string.IsNullOrEmpty(request.Usuario) || string.IsNullOrEmpty(request.Password)) 
            throw new BadRequestException("Introducir usuario y contraseña.");

        var dbUser = await _userRepository.UserInDB(request);

        if (dbUser == null) 
            throw new BadRequestException("Usuario no registrado en el sistema.");

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
