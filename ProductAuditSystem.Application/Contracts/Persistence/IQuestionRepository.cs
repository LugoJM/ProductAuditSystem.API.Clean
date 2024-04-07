
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Contracts.Persistence;

public interface IQuestionRepository : IGenericRepository<Question>
{
    Task AddAuditQuestions(List<Question> questionList);
    Task<List<Question>> GetQuestions();
    Task<Question> GetQuestionById(int id);
    Task<List<Question>> GetAuditQuestions(int auditID);
    Task DeleteAuditQuestions(List<Question> questions);
}
