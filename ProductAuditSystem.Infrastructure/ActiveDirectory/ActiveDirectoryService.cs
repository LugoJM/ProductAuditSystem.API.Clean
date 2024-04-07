using ProductAuditSystem.Application.Contracts.Infrastructure.ActiveDirectory;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Features.Users.Commands.Login;
using System.DirectoryServices;

namespace ProductAuditSystem.Infrastructure.ActiveDirectory;

#pragma warning disable CA1416
#nullable disable
public class ActiveDirectoryService : IActiveDirectory
{
    public WindowsUser searchUser(string username)
    {
        try
        {
            DirectoryEntry entry = new("LDAP://" + "AUTO");
            DirectorySearcher mySearcher = new(entry);
            mySearcher.Filter = $"(&(objectClass=user)(|(cn={username})(sAMAccountName={username})))";
            SearchResult result = mySearcher.FindOne();

            if (result != null)
            {
                try
                {
                    return new WindowsUser
                    {
                        Nombre = result.Properties["displayname"][0].ToString(),
                        Correo = result.Properties["mail"][0].ToString(),
                    };
                }
                catch (Exception)
                {
                    return new WindowsUser
                    {
                        Nombre = result.Properties["displayname"][0].ToString(),
                        Correo = "error",
                    };
                }
            }
        }
        catch (DirectoryServicesCOMException)
        {
        }
        return null;
    }

    public bool login(CommandUserLogin loginUsuario)
    {
        (string usuario, string password) = loginUsuario;
        return true;
        //try
        //{
        //    DirectoryEntry entry = new DirectoryEntry("LDAP://" + "AUTO", usuario, password);
        //    DirectorySearcher mySearcher = new DirectorySearcher(entry);
        //    mySearcher.Filter = "(&(objectClass=user)(|(cn=" + usuario + ")(sAMAccountName=" + usuario + ")))";
        //    SearchResult result = mySearcher.FindOne();

        //    if (result == null) return false;

        //    return true;
        //}
        //catch (DirectoryServicesCOMException e)
        //{
        //    if(e.ErrorCode == -2147023570)
        //        throw new BadRequestException("Usuario y/o contraseña incorrecta.");
        //    throw new Exception("Error con Active Directory.");
        //}
    }
}
