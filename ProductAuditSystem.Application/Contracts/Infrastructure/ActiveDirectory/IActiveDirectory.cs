using ProductAuditSystem.Application.Features.Users.Commands.Login;

namespace ProductAuditSystem.Application.Contracts.Infrastructure.ActiveDirectory;

public interface IActiveDirectory
{
    bool login(CommandUserLogin loginUsuario);

    WindowsUser searchUser(string username);
}
