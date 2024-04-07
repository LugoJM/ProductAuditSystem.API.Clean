
using MediatR;

namespace ProductAuditSystem.Application.Features.Users.Commands.Login;

public class CommandUserLogin : IRequest<UserInfoDTO>
{
    public required string Usuario { get; set; }
    public required string Password { get; set; }

    public void Deconstruct(out string usuario, out string password)
    {
        usuario = Usuario;
        password = Password;
    }
}
