
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Contracts.Persistence;

public interface IOEMsRepository  : IGenericRepository<OEM>
{
    Task<OEM?> FindOEM(string oemName);
    Task<bool> CheckOEM(OEM oem);
}
