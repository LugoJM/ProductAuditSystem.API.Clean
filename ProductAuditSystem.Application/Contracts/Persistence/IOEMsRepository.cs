
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Contracts.Persistence;

public interface IOEMsRepository  : IGenericRepository<OEM>
{
    Task<bool> CheckOEM(OEM oem);
}
