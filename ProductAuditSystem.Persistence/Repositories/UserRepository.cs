using Microsoft.EntityFrameworkCore;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Features.Users.Commands.Login;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Persistence.DataBaseContext;

namespace ProductAuditSystem.Persistence.Repositories;

#nullable disable
public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ProductAuditSystemDBContext context) : base(context)
    {
    }

    public async Task<bool> CheckUser(User user)
    {
        var userExists = await _context.Users
            .AnyAsync(u => u.Username == user.Username);
        return userExists;
    }

    public async Task<User> GetUser(string username)
    {
        var user = await _context.Users
            .AsNoTracking()
            .Include(r => r.Rol)
            .FirstOrDefaultAsync(u => u.Username == username);
        return user;
    }

    public async Task<User> GetUserById(int ID)
    {
        var user = await _context.Users
            .AsNoTracking()
            .Include(r => r.Rol)
            .FirstOrDefaultAsync(u => u.Id == ID);
        return user;
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await _context.Users
            .AsNoTracking()
            .Include(r => r.Rol)
            .ToListAsync();
        return users;
    }

    public async Task<User> UserInDB(CommandUserLogin usuario)
    {
        var DB_User = await _context.Users
            .AsNoTracking()
            .Where(x => x.Username == usuario.Usuario)
            .Include(r => r.Rol)
            .FirstOrDefaultAsync();
        return DB_User;
    }
}


