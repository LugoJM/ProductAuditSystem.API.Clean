
using Microsoft.EntityFrameworkCore;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Persistence.DataBaseContext;

#nullable disable

namespace ProductAuditSystem.Persistence.Repositories;

public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
{
    public QuestionRepository(ProductAuditSystemDBContext context) : base(context)
    {
    }

    public async Task AddAuditQuestions(List<Question> questionList)
    {
        _context.AddRange(questionList);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAuditQuestions(List<Question> questions)
    {
        foreach (var question in questions)
        {
            question.PuntosAEvaluar?.Clear();
            question.Files?.Clear();
        }
        _context.RemoveRange(questions);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Question>> GetAuditQuestions(int auditID)
    {
        var auditQuestions = await _context.Questions
            .Include(q => q.PuntosAEvaluar)
            .Include(q => q.Files)
            .Where(q => q.AuditoriasPreguntas.Any(aq => aq.AuditoriaID == auditID))
            .ToListAsync();

        return auditQuestions;
    }

    public async Task<Question> GetQuestionById(int id)
    {
        var question = await _context.Questions
            .Include(dpto => dpto.Soporte)
            .Include(pe => pe.PuntosAEvaluar)
            .ThenInclude(pes => pes.StatusPunto)
            .Include(f => f.Files)
            .SingleOrDefaultAsync(q => q.Id == id);
        return question;
    }

    public async Task<List<Question>> GetQuestions()
    {
        var questions = await _context.Questions
            .Include(dpto => dpto.Soporte)
            .Include(pe => pe.PuntosAEvaluar)
            .ThenInclude(pes => pes.StatusPunto)
            .Include(f => f.Files)
            .ToListAsync();
        return questions;
    }
}
