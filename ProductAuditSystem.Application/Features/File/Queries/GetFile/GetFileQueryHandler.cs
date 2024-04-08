
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Features.File.Queries.GetFile;

internal sealed class GetFileQueryHandler : IRequestHandler<GetFileQuery, FilesDTO>
{
    private readonly IFilesRepository _filesRepository;
    private readonly IMapper _mapper;

    public GetFileQueryHandler(IFilesRepository filesRepository, IMapper mapper)
    {
        _filesRepository = filesRepository;
        _mapper = mapper;
    }

    public async Task<FilesDTO> Handle(GetFileQuery request, CancellationToken cancellationToken)
    {
        var file = await _filesRepository.GetFile(request.FileID);

        if (file == null)
            throw new NotFoundException(nameof(file), request.FileID);

        var data = _mapper.Map<FilesDTO>(file);

        return data;
    }
}