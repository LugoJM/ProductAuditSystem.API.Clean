
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.File.Commands.DeleteFile;

internal sealed class CommandDeleteFileHandler : IRequestHandler<CommandDeleteFile, BaseCommandResponse>
{
    private readonly IFilesRepository _filesRepository;

    public CommandDeleteFileHandler(IFilesRepository filesRepository)
    {
        _filesRepository = filesRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandDeleteFile request, CancellationToken cancellationToken)
    {
        var fileToDelete = await _filesRepository.GetFile(request.FileID);

        if(fileToDelete == null)
            throw new NotFoundException(nameof(fileToDelete), request.FileID);

        await _filesRepository.DeleteFile(fileToDelete);

        return new BaseCommandResponse
        {
            Id = request.FileID,
            Message = $"Se ha eliminado exitosamente el archivo con ID:{request.FileID}",
            Success = true
        };
    }
}
