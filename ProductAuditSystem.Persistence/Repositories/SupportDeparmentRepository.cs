
using Microsoft.EntityFrameworkCore;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Persistence.DataBaseContext;

namespace ProductAuditSystem.Persistence.Repositories;

public class SupportDeparmentRepository : GenericRepository<SupportDepartment>, ISupportDepartmentRepository
{
    public SupportDeparmentRepository(ProductAuditSystemDBContext context) : base(context)
    {
    }

    public async Task<SupportDepartment?> FindSupportDepartment(string departmentName)
    {
        var query = _context.SupportDepartment.AsNoTracking().AsQueryable();

        if (!string.IsNullOrEmpty(departmentName))
        {
            query = query.Where(r => r.Department.Equals(departmentName));
        }

        var supportDepartment = await query.FirstOrDefaultAsync();
        return supportDepartment;
    }
}
