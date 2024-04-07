
using MediatR;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Features.File.Queries.GetFiles;

public record GetFilesQuery(int QuestionID) : IRequest<List<Files>>;