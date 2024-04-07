
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Features.File.Queries.GetFiles;

internal sealed class GetFilesQueryHandler : IRequestHandler<GetFilesQuery, List<Files>>
{
    private readonly IFilesRepository _filesRepository;

    public GetFilesQueryHandler(IFilesRepository filesRepository)
    {
        _filesRepository = filesRepository;
    }
    public Task<List<Files>> Handle(GetFilesQuery request, CancellationToken cancellationToken)
    {
        var files = _filesRepository.GetFiles(request.QuestionID);

        return files;
    }
}
