
using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.File.Commands.DeleteFile;

public record CommandDeleteFile(int FileID) : IRequest<BaseCommandResponse>;
