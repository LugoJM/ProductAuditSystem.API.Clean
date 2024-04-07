
using ProductAuditSystem.Application.Features.Users.Commands.Login;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> UserInDB (CommandUserLogin user);
    Task<List<User>> GetUsers();
    Task<User> GetUser(string username);
    Task<User> GetUserById(int ID);
    Task<bool> CheckUser(User user);
}