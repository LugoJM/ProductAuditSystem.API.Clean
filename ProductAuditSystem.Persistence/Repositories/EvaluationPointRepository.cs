
using Microsoft.EntityFrameworkCore;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Persistence.DataBaseContext;

#nullable disable

namespace ProductAuditSystem.Persistence.Repositories;

public class EvaluationPointRepository : GenericRepository<EvaluationPoint>, IEvaluationPointRepository
{
    public EvaluationPointRepository(ProductAuditSystemDBContext context) : base(context)
    {
    }

    public async Task AddQuestionEvaluationPoints(List<EvaluationPoint> evaluationPoints)
    {
        _context.EvaluationPoints.AddRange(evaluationPoints);
        await _context.SaveChangesAsync();
    }

    public async Task<List<EvaluationPoint>> GetEvaluationPoints(int questionID)
    {
        var evaluationPoints = await _context.EvaluationPoints
            .Where(ep => ep.Pregunta != null && ep.Pregunta.Id == questionID)
            .Include(ps => ps.StatusPunto)
            .ToListAsync();

        return evaluationPoints;
    }

    public async Task UpdateEvaluationPoints(List<EvaluationPoint> evaluationPoints)
    {
        _context.EvaluationPoints.UpdateRange(evaluationPoints);
        await _context.SaveChangesAsync();
    }
}
