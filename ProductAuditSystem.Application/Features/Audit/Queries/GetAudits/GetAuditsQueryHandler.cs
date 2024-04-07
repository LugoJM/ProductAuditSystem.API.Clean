using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Contracts.Persistence;

#nullable disable

namespace ProductAuditSystem.Application.Features.Audit.Queries.GetAudits;

internal sealed class GetAuditsQueryHandler : IRequestHandler<GetAuditsQuery, List<GetAuditsDTO>>
{
    private readonly IMapper _mapper;
    private readonly IAuditRepository _auditRepository;
    private readonly IUserRepository _userRepository;
    private readonly IQuestionRepository _questionRepository;

    public GetAuditsQueryHandler(IMapper mapper, IAuditRepository auditRepository,
        IUserRepository userRepository, IQuestionRepository questionRepository)
    {
        _mapper = mapper;
        _auditRepository = auditRepository;
        _userRepository = userRepository;
        _questionRepository = questionRepository;
    }
    public async Task<List<GetAuditsDTO>> Handle(GetAuditsQuery request, CancellationToken cancellationToken)
    {
        var auditorias = await _auditRepository.GetAllAsync();

        var datos = _mapper.Map<List<GetAuditsDTO>>(auditorias);

        foreach (var audit in datos)
        {
            var auditores = auditorias
                .FirstOrDefault(a => a.Id == audit.Id)
                .UsuariosAuditorias
                .Select(au => _mapper.Map<UserDTO>(_userRepository.GetUserById(au.UsuarioID).Result))
                .ToList();

            var preguntas = auditorias
                .FirstOrDefault(a => a.Id == audit.Id)
                .AuditoriasPreguntas
                .Select(aq => _mapper.Map<QuestionDTO>(_questionRepository.GetQuestionById(aq.PreguntaID).Result))
                .ToList();

            audit.Auditores = auditores ?? new List<UserDTO>();
        }
        return datos;
    }
}
