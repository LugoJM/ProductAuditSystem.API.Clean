using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Persistence.DataBaseContext;

namespace ProductAuditSystem.Persistence.Repositories;

public class RolesRepository : GenericRepository<Rol>, IRolesRepository
{
    public RolesRepository(ProductAuditSystemDBContext context) : base(context)
    {
    }
}
