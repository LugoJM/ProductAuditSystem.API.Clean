
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Features.File.Queries.GetFile;

internal sealed class GetFileQueryHandler : IRequestHandler<GetFileQuery, Files>
{
    private readonly IFilesRepository _filesRepository;

    public GetFileQueryHandler(IFilesRepository filesRepository)
    {
        _filesRepository = filesRepository;
    }

    async Task<Files> IRequestHandler<GetFileQuery, Files>.Handle(GetFileQuery request, CancellationToken cancellationToken)
    {
        var file = await _filesRepository.GetFile(request.FileID);

        if (file == null)
            throw new NotFoundException(nameof(file), request.FileID);

        return file;
    }
}
