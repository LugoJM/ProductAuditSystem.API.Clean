
using Microsoft.EntityFrameworkCore;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Persistence.DataBaseContext;

namespace ProductAuditSystem.Persistence.Repositories;

#nullable disable

public class AuditUserRepository : GenericRepository<AuditUser>, IAuditUserRepository
{
    public AuditUserRepository(ProductAuditSystemDBContext context) : base(context)
    {
    }

    public async Task AddAuditUsers(List<AuditUser> users)
    {
        _context.AddRange(users);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAuditUsers(int AuditID, List<AuditUser> updatedAuditUsers)
    {
        string deleteAuditUsers = $"DELETE FROM AuditUser WHERE AuditoriaID = {AuditID}";

        await _context.Database.ExecuteSqlRawAsync(deleteAuditUsers);

        _context.AddRange(updatedAuditUsers);

        await _context.SaveChangesAsync();
    }
}
