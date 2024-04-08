using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Contracts.Persistence;

public interface IRolesRepository : IGenericRepository<Rol>
{
    Task<Rol?> FindRole(string roleName);
}
