using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Features.File.Commands.Addfiles;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.File.Commands.Addfile;

#nullable disable

internal sealed class CommandAddFilesHandler : IRequestHandler<CommandAddFiles, BaseCommandResponse>
{
    private readonly IFilesRepository _filesRepository;
    private readonly IQuestionRepository _questionRespository;
    private readonly ProccessFiles _proccessFiles = new();

    public CommandAddFilesHandler(IFilesRepository filesRepository, IQuestionRepository questionRespository)
    {
        _filesRepository = filesRepository;
        _questionRespository = questionRespository;
    }

    public async Task<BaseCommandResponse> Handle(CommandAddFiles request, CancellationToken cancellationToken)
    {
        var validator = new CommandAddFilesValidator(_questionRespository);
        var validationResults = await validator.ValidateAsync(request, cancellationToken);

        if (validationResults.Errors.Any())
            throw new BadRequestException("Comando Agregar Archivos Invalido", validationResults);

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
