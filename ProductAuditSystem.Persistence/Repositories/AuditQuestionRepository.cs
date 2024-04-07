
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Persistence.DataBaseContext;

namespace ProductAuditSystem.Persistence.Repositories;

public class AuditQuestionRepository : GenericRepository<AuditQuestion>, IAuditQuestionRepository
{
    public AuditQuestionRepository(ProductAuditSystemDBContext context) : base(context)
    {
    }
}
