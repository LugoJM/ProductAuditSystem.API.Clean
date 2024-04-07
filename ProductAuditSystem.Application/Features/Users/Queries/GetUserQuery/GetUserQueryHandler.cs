
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;

namespace ProductAuditSystem.Application.Features.Users.Queries.GetUserQuery;

internal sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDTO>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<UserDTO> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var usuario = await _userRepository.GetUser(request.Username);

        if (usuario == null)
            throw new NotFoundException(nameof(usuario), request.Username);

        var datos = _mapper.Map<UserDTO>(usuario);

        return datos;
    }
}
