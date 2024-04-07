
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.Question.Queries.GetQuestions;

#nullable disable

internal sealed class GetQuestionsQueryHandler : IRequestHandler<GetQuestionsQuery, List<QuestionDTO>>
{
    private readonly IMapper _mapper;
    private readonly IQuestionRepository _questionRepository;

    public GetQuestionsQueryHandler(IMapper mapper, IQuestionRepository questionRepository)
    {
        _mapper = mapper;
        _questionRepository = questionRepository;
    }
    public async Task<List<QuestionDTO>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
    {
        var questions = await _questionRepository.GetQuestions();

        var questionDTOs = questions.Select(question =>
        {
            var questionDTO = _mapper.Map<QuestionDTO>(question);

            questionDTO.ReferenceFiles = _mapper.Map<List<FilesDTO>>(question.Files?.Where(f => f.IsReference).ToList());
            questionDTO.EvidenceFiles = _mapper.Map<List<FilesDTO>>(question.Files?.Where(f => !f.IsReference).ToList());

            return questionDTO;
        }).ToList();

        return questionDTOs;
    }

}
