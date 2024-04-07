
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Features.PointStatus.Commands.CreatePointStatus;
using ProductAuditSystem.Application.Features.PointStatus.Commands.UpdatePointStatus;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.MappingProfiles;

public class PointStatusProfile : Profile
{
    public PointStatusProfile()
    {
        CreateMap<PointStatusDTO, PointStatus>().ReverseMap();
        CreateMap<PointStatus, Unit>();
        CreateMap<CommandCreateStatusPoint, PointStatus>();
        CreateMap<CommandUpdatePointStatus, PointStatus>();
        CreateMap<PointStatus, PointStatusDTO>();
    }
}
