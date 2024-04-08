
using Microsoft.EntityFrameworkCore;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Persistence.DataBaseContext;

namespace ProductAuditSystem.Persistence.Repositories;

public class AuditStatusRepository : GenericRepository<AuditStatus>, IAuditStatusRepository
{
    public AuditStatusRepository(ProductAuditSystemDBContext context) : base(context)
    {
    }

    public async Task<AuditStatus?> FindStatus(string status)
    {
        var query = _context.AuditStatus.AsNoTracking().AsQueryable();

        if (!string.IsNullOrEmpty(status))
        {
            query = query.Where(au => au.Status.Equals(status));
        }

        var auditStatus = await query.FirstOrDefaultAsync();
        return auditStatus;
    }
}
