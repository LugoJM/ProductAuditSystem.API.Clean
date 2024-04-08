
using Microsoft.EntityFrameworkCore;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Persistence.DataBaseContext;

namespace ProductAuditSystem.Persistence.Repositories;

public class PointStatusRepository : GenericRepository<PointStatus>, IPointStatusRepository
{
    public PointStatusRepository(ProductAuditSystemDBContext context) : base(context)
    {
    }

    public async Task<PointStatus?> FindPointStatus(string status)
    {
        var query = _context.PointStatus.AsNoTracking().AsQueryable();

        if (!string.IsNullOrEmpty(status))
        {
            query = query.Where(ps => ps.Status.Equals(status));
        }

        var pointStatus = await query.FirstOrDefaultAsync();
        return pointStatus;
    }
}
