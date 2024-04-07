
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Persistence.DataBaseContext;

namespace ProductAuditSystem.Persistence.Repositories;

public class SupportDeparmentRepository : GenericRepository<SupportDepartment>, ISupportDepartmentRepository
{
    public SupportDeparmentRepository(ProductAuditSystemDBContext context) : base(context)
    {
    }
}
