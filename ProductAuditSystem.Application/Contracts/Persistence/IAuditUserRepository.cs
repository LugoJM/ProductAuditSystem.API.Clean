
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Contracts.Persistence;

public interface IAuditUserRepository : IGenericRepository<AuditUser>
{
    Task AddAuditUsers(List<AuditUser> users);

    Task UpdateAuditUsers(int AuditID, List<AuditUser> updatedAuditUsers);
}
