
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Features.File.Queries.GetFiles;

internal sealed class GetFilesQueryHandler : IRequestHandler<GetFilesQuery, List<FilesDTO>>
{
    private readonly IFilesRepository _filesRepository;
    private readonly IMapper _mapper;

    public GetFilesQueryHandler(IFilesRepository filesRepository, IMapper mapper)
    {
        _filesRepository = filesRepository;
        _mapper = mapper;
    }

    public async Task<List<FilesDTO>> Handle(GetFilesQuery request, CancellationToken cancellationToken)
    {
        var files = await _filesRepository.GetFiles(request.QuestionID);

        var data = _mapper.Map<List<FilesDTO>>(files);

        return data;
    }
}
