
using MediatR;

namespace ProductAuditSystem.Application.Features.Users.Commands.Login;

public class CommandUserLogin : IRequest<UserInfoDTO>
{
    public string Usuario { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty; 

    public void Deconstruct(out string usuario, out string password)
    {
        usuario = Usuario;
        password = Password;
    }
}
