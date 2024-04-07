
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Persistence.DataBaseContext;

namespace ProductAuditSystem.Persistence.Repositories;

public class PointStatusRepository : GenericRepository<PointStatus>, IPointStatusRepository
{
    public PointStatusRepository(ProductAuditSystemDBContext context) : base(context)
    {
    }
}
