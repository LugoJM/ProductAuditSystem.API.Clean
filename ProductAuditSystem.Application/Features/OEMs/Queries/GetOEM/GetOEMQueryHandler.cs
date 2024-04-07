
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;

namespace ProductAuditSystem.Application.Features.OEMs.Queries.GetOEM;

public class GetOEMQueryHandler : IRequestHandler<GetOEMQuery, OEM_DTO>
{
    private readonly IMapper _mapper;
    private readonly IOEMsRepository _OEMsRepository;

    public GetOEMQueryHandler(IMapper mapper, IOEMsRepository OEMsRepository)
    {
        _mapper = mapper;
        _OEMsRepository = OEMsRepository;
    }
    public async Task<OEM_DTO> Handle(GetOEMQuery request, CancellationToken cancellationToken)
    {
        var OEM = await _OEMsRepository.GetByIdAsync(request.Id);

        if (OEM == null)
            throw new NotFoundException(nameof(OEM), request.Id);

        var datos = _mapper.Map<OEM_DTO>(OEM);

        return datos;
    }
}

