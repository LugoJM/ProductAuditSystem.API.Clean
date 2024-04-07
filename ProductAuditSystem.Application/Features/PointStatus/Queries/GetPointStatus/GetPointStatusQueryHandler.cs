
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;

namespace ProductAuditSystem.Application.Features.PointStatus.Queries.GetPointStatus;

internal sealed class GetPointStatusQueryHandler : IRequestHandler<GetPointStatusQuery, PointStatusDTO>
{
    private readonly IMapper _mapper;
    private readonly IPointStatusRepository _pointStatusRepository;

    public GetPointStatusQueryHandler(IMapper mapper, IPointStatusRepository pointStatusRepository)
    {
        _mapper = mapper;
        _pointStatusRepository = pointStatusRepository;
    }
    public async Task<PointStatusDTO> Handle(GetPointStatusQuery request, CancellationToken cancellationToken)
    {
        var statusPunto = await _pointStatusRepository.GetByIdAsync(request.Id);

        if (statusPunto == null)
            throw new NotFoundException(nameof(statusPunto), request.Id);

        var datos = _mapper.Map<PointStatusDTO>(statusPunto);

        return datos;
    }
}
