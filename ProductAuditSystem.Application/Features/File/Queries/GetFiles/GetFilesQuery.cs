
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.Application.Features.File.Queries.GetFiles;

public record GetFilesQuery(int QuestionID) : IRequest<List<FilesDTO>>;