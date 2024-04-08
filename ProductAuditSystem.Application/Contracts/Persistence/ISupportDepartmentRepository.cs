
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Contracts.Persistence;

public interface ISupportDepartmentRepository : IGenericRepository<SupportDepartment>
{
    Task<SupportDepartment?> FindSupportDepartment(string departmentName);
}
