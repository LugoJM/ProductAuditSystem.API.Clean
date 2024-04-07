
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.Application.Features.Question.Queries.GetQuestion;

public record GetQuestionQuery(int Id) : IRequest<QuestionDTO>;
