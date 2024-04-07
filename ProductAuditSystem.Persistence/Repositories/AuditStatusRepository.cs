
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Persistence.DataBaseContext;

namespace ProductAuditSystem.Persistence.Repositories;

public class AuditStatusRepository : GenericRepository<AuditStatus>, IAuditStatusRepository
{
    public AuditStatusRepository(ProductAuditSystemDBContext context) : base(context)
    {
    }
}
