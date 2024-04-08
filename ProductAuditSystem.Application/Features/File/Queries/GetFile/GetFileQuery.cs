
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.Application.Features.File.Queries.GetFile;

public record GetFileQuery(int FileID) : IRequest<FilesDTO>;
