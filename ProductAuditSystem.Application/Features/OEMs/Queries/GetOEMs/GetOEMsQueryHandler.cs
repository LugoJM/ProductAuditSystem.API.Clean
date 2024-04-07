
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.OEMs.Queries.GetOEMs;

internal sealed class GetOEMsQueryHandler : IRequestHandler<GetOEMsQuery, List<OEM_DTO>>
{
    private readonly IMapper _mapper;
    private readonly IOEMsRepository _OEMsRepository;

    public GetOEMsQueryHandler(IMapper mapper, IOEMsRepository OEMsRepository)
    {
        _mapper = mapper;
        _OEMsRepository = OEMsRepository;
    }
    public async Task<List<OEM_DTO>> Handle(GetOEMsQuery request, CancellationToken cancellationToken)
    {
        var OEMs = await _OEMsRepository.GetAsync();

        var datos = _mapper.Map<List<OEM_DTO>>(OEMs);

        return datos;
    }
}
