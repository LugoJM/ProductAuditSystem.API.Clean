using ProductAuditSystem.Application.Features.Audit;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Contracts.Persistence;

public interface IAuditRepository : IGenericRepository<Audit>
{
    Task<List<Audit>> GetAllAsync();
    Task<Audit> GetAudit(int id);   
}
