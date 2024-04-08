
using Microsoft.EntityFrameworkCore;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Persistence.DataBaseContext;

namespace ProductAuditSystem.Persistence.Repositories;

public class OEMRepository : GenericRepository<OEM>, IOEMsRepository
{
    public OEMRepository(ProductAuditSystemDBContext context) : base(context)
    {
    }

    public async Task<bool> CheckOEM(OEM oem)
    {
        var OEMExists = await _context.OEMs.AnyAsync(u => u.Nombre == oem.Nombre);
        return OEMExists;
    }

    public async Task<OEM?> FindOEM(string oemName)
    {
        var query = _context.OEMs.AsNoTracking().AsQueryable();
        if (!string.IsNullOrEmpty(oemName))
        {
            query = query.Where(oem => oem.Nombre.Equals(oemName));
        }
        var oem = await query.FirstOrDefaultAsync();
        return oem;
    }
}
