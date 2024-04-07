
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.SupportDepartment.Queries.GetSupportDeparments;

internal sealed class GetSupportDeparmentsQueryHandler : IRequestHandler<GetSupportDeparmentsQuery, List<GetSupportDeparmentDTO>>
{
    private readonly IMapper _mapper;
    private readonly ISupportDepartmentRepository _supportDepartmentRepository;

    public GetSupportDeparmentsQueryHandler(IMapper mapper, ISupportDepartmentRepository supportDepartmentRepository)
    {
        _mapper = mapper;
        _supportDepartmentRepository = supportDepartmentRepository;
    }
    public async Task<List<GetSupportDeparmentDTO>> Handle(GetSupportDeparmentsQuery request, CancellationToken cancellationToken)
    {
        var supportDepartments = await _supportDepartmentRepository.GetAsync();

        var datos = _mapper.Map<List<GetSupportDeparmentDTO>>(supportDepartments);

        return datos;
    }
}
