using Microsoft.EntityFrameworkCore;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Persistence.DataBaseContext;

namespace ProductAuditSystem.Persistence.Repositories;

public class RolesRepository : GenericRepository<Rol>, IRolesRepository
{
    public RolesRepository(ProductAuditSystemDBContext context) : base(context)
    {
    }

    public async Task<Rol?> FindRole(string roleName)
    {
        var query = _context.Roles.AsNoTracking().AsQueryable();

        if (!string.IsNullOrEmpty(roleName))
        {
            query = query.Where(r => r.RolNombre.Equals(roleName));
        }

        var role = await query.FirstOrDefaultAsync();
        return role;
    }
}
