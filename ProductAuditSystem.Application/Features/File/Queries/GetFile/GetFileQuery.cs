
using MediatR;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Features.File.Queries.GetFile;

public record GetFileQuery(int FileID) : IRequest<Files>;
