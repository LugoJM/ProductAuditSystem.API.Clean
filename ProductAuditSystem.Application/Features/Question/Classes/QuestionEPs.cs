
namespace ProductAuditSystem.Application.Features.Question.Classes;

public class QuestionEPs
{
    public string Comments { get; set; } = string.Empty;
    public List<QuestionEP>? Points { get; set; }
}
