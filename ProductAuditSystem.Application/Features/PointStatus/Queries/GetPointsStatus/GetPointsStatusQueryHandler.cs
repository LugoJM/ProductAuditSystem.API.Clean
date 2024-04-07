
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.PointStatus.Queries.GetPointsStatus;

internal sealed class GetPointsStatusQueryHandler : IRequestHandler<GetPointsStatusQuery, List<PointStatusDTO>>
{
    private readonly IMapper _mapper;
    private readonly IPointStatusRepository _pointStatusRepository;

    public GetPointsStatusQueryHandler(IMapper mapper, IPointStatusRepository pointStatusRepository)
    {
        _mapper = mapper;
        _pointStatusRepository = pointStatusRepository;
    }
    public async Task<List<PointStatusDTO>> Handle(GetPointsStatusQuery request, CancellationToken cancellationToken)
    {
        var statusPuntos = await _pointStatusRepository.GetAsync();

        var datos = _mapper.Map<List<PointStatusDTO>>(statusPuntos);

        return datos;
    }
}
