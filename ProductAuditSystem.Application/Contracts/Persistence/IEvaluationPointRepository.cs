
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Contracts.Persistence;

public interface IEvaluationPointRepository : IGenericRepository<EvaluationPoint>
{
    Task<List<EvaluationPoint>> GetEvaluationPoints(int questionID);

    Task AddQuestionEvaluationPoints(List<EvaluationPoint> evaluationPoints);

    Task UpdateEvaluationPoints(List<EvaluationPoint> evaluationPoints);
}
