using ProductAuditSystem.Domain;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProductAuditSystem.Persistence.Repositories;
public class AuditRepository : GenericRepository<Audit>, IAuditRepository
{
    public AuditRepository(ProductAuditSystemDBContext context) : base(context)
    {
    }

    public async Task<List<Audit>> GetAllAsync()
    {
        var audits = await _context.Audits.Include(aq => aq.AuditoriasPreguntas)
            .Include(au => au.UsuariosAuditorias)
            .Include(oem => oem.OEM)
            .Include(sts => sts.Status)
            .ToListAsync();
        return audits;
    }

    public async Task<Audit> GetAudit(int id)
    {
        var audit = await _context.Audits
            .AsNoTracking()
            .Include(aq => aq.AuditoriasPreguntas)
            .ThenInclude(p => p.Pregunta)
            .ThenInclude(dpto => dpto.Soporte)
            .Include(aq => aq.AuditoriasPreguntas)
            .ThenInclude(aq => aq.Pregunta)
            .ThenInclude(pe => pe.PuntosAEvaluar)
            .ThenInclude(pes => pes.StatusPunto)
            .Include(aq => aq.AuditoriasPreguntas)
            .ThenInclude(aq => aq.Pregunta)
            .ThenInclude(f => f.Files)
            .Include(au => au.UsuariosAuditorias)
            .ThenInclude(u => u.Usuario)
            .Include(oem => oem.OEM)
            .Include(sts => sts.Status)
            .FirstOrDefaultAsync(a => a.Id == id);
        return audit;
    }
}