using MediatR;
using Microsoft.AspNetCore.Http;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Responses;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Features.File.Commands.Addfile;

#nullable disable

internal sealed class CommandAddFilesHandler : IRequestHandler<CommandAddFiles, BaseCommandResponse>
{
    private readonly IFilesRepository _filesRepository;
    private readonly ProccessFiles _proccessFiles;

    public CommandAddFilesHandler(IFilesRepository filesRepository)
    {
        _filesRepository = filesRepository;
        _proccessFiles = new();
    }
    public async Task<BaseCommandResponse> Handle(CommandAddFiles request, CancellationToken cancellationToken)
    {
        var filesEntities = await _proccessFiles.GetFiles(request.Files, request.QuestionId, 
            request.IsReference, request.IsReferenceDocument);

        await _filesRepository.AddFiles(filesEntities);

        return new BaseCommandResponse
        {
            Message = "Se han guardado correctamente los archivo(s)",
            Success = true
        };
    }
}
