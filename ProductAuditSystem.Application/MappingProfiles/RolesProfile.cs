using AutoMapper;
using MediatR;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Application.Features.Roles.Commands.CommandUpdateRol;
using ProductAuditSystem.Application.Features.Roles.Commands.CommandCreateRol;
using ProductAuditSystem.Application.Features.Roles.Queries;

namespace ProductAuditSystem.Application.MappingProfiles;

public class RolesProfile : Profile
{
    public RolesProfile()
    {
        CreateMap<GetRolDTO, Rol>().ReverseMap();
        CreateMap<Rol, Unit>();
        CreateMap<CommandCreateRol, Rol>();
        CreateMap<CommandUpdateRol, Rol>();
    }
}
