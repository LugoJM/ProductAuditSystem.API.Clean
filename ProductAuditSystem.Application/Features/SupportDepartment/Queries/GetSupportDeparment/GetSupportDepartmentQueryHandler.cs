
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;

namespace ProductAuditSystem.Application.Features.SupportDepartment.Queries.GetSupportDeparment;

internal sealed class GetSupportDepartmentQueryHandler : IRequestHandler<GetSupportDeparmentQuery, GetSupportDeparmentDTO>
{
    private readonly IMapper _mapper;
    private readonly ISupportDepartmentRepository _supportDepartmentRepository;

    public GetSupportDepartmentQueryHandler(IMapper mapper, ISupportDepartmentRepository supportDepartmentRepository)
    {
        this._mapper = mapper;
        this._supportDepartmentRepository = supportDepartmentRepository;
    }
    public async Task<GetSupportDeparmentDTO> Handle(GetSupportDeparmentQuery request, CancellationToken cancellationToken)
    {
        var supportDepartment = await _supportDepartmentRepository.GetByIdAsync(request.Id);

        if (supportDepartment == null)
            throw new NotFoundException(nameof(supportDepartment), request.Id);

        var datos = _mapper.Map<GetSupportDeparmentDTO>(supportDepartment);

        return datos;
    }
}
