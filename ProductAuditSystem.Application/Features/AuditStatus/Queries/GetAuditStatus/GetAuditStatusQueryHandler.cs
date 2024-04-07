
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;

namespace ProductAuditSystem.Application.Features.AuditStatus.Queries.GetAuditStatus;

internal sealed class GetAuditStatusQueryHandler : IRequestHandler<GetAuditStatusQuery, AuditStatusDTO>
{
    private readonly IMapper _mapper;
    private readonly IAuditStatusRepository _auditStatusRepository;

    public GetAuditStatusQueryHandler(IMapper mapper, IAuditStatusRepository auditStatusRepository)
    {
        _mapper = mapper;
        _auditStatusRepository = auditStatusRepository;
    }
    public async Task<AuditStatusDTO> Handle(GetAuditStatusQuery request, CancellationToken cancellationToken)
    {
        var auditStatus = await _auditStatusRepository.GetByIdAsync(request.Id);

        if (auditStatus == null)
            throw new NotFoundException(nameof(auditStatus), request.Id);

        var data = _mapper.Map<AuditStatusDTO>(auditStatus);

        return data;
    }
}
