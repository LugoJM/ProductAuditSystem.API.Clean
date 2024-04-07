using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Contracts.Persistence;
namespace ProductAuditSystem.Application.Features.AuditStatus.Queries.GetAuditsStatus;

internal sealed class GetAuditsStatusQueryHandler : IRequestHandler<GetAuditsStatusQuery, List<AuditStatusDTO>>
{
    private readonly IMapper _mapper;
    private readonly IAuditStatusRepository _auditStatusRepository;

    public GetAuditsStatusQueryHandler(IMapper mapper, IAuditStatusRepository auditStatusRepository)
    {
        _mapper = mapper;
        _auditStatusRepository = auditStatusRepository;
    }
    public async Task<List<AuditStatusDTO>> Handle(GetAuditsStatusQuery request, CancellationToken cancellationToken)
    {
        var auditStatus = await _auditStatusRepository.GetAsync();

        var data = _mapper.Map<List<AuditStatusDTO>>(auditStatus);

        return data;
    }
}
