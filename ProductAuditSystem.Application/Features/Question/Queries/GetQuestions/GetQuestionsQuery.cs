
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.Application.Features.Question.Queries.GetQuestions;

public record GetQuestionsQuery : IRequest<List<QuestionDTO>>;
