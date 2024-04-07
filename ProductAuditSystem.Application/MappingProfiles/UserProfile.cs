
using AutoMapper;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Features.Users.Commands.CreateUser;
using ProductAuditSystem.Application.Features.Users.Commands.UpdateUser;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.MappingProfiles;

#nullable disable warnings
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>().ForMember(dest => dest.Rol, opt => opt.MapFrom(src => new RolDTO
        {
            Id = src.Rol.Id,
            RolNombre = src.Rol.RolNombre
        }));
        CreateMap<CommandCreateUser, User>();
        CreateMap<CommandUpdateUser, User>();
    }
}
