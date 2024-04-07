using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Features.Audit.Commands.CreateAudit;
using ProductAuditSystem.Application.Features.Audit.Commands.UpdateAudit;
using ProductAuditSystem.Application.Features.Audit.Queries.GetAudit;
using ProductAuditSystem.Application.Features.Audit.Queries.GetAudits;
using ProductAuditSystem.Domain;

#nullable disable

namespace ProductAuditSystem.Application.MappingProfiles;

public class AuditoriasProfile : Profile
{
    public AuditoriasProfile()
    {
        CreateMap<Audit, GetAuditsDTO>()
            .ForMember(dest => dest.Auditores, opt => opt.MapFrom(src => 
            src.UsuariosAuditorias.Select(user => new UserDTO
            {
                Id = user.Usuario.Id,
                Username = user.Usuario.Username,
                Nombre = user.Usuario.Nombre,
                Correo = user.Usuario.Correo,
                Rol = new RolDTO
                {
                    Id = user.Usuario.Rol.Id,
                    RolNombre = user.Usuario.Rol.RolNombre
                }
            }).ToList()));
        CreateMap<Audit, GetAuditDTO>()
            .ForMember(dest => dest.Auditores, opt => opt.MapFrom(src => 
            src.UsuariosAuditorias.Select(user => new UserDTO
            {
                Id = user.Usuario.Id,
                Username = user.Usuario.Username,
                Nombre = user.Usuario.Nombre,
                Correo = user.Usuario.Correo,
                Rol = new RolDTO
                {
                    Id = user.Usuario.Rol.Id,
                    RolNombre = user.Usuario.Rol.RolNombre
                }
            }).ToList()));
        CreateMap<CommandCreateAudit, Audit>()
            .ForMember(dest => dest.StatusID, opt => opt.MapFrom(src => src.AuditoriaStatus.Id))
            .ForMember(dest => dest.OEMID, opt => opt.MapFrom(src => src.AuditoriaOEM.Id));
        CreateMap<Audit, GetAuditsDTO>();
        CreateMap<Audit, GetAuditDTO>();
        CreateMap<Audit, Unit>();
        CreateMap<CommandUpdateAudit, Audit>()
            .ForMember(dest => dest.StatusID, opt => opt.MapFrom(src => src.Status.Id))
            .ForMember(dest => dest.OEMID, opt => opt.MapFrom(src => src.OEM.Id));
    }
}
