using AutoMapper;
using Moq;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Features.AuditStatus.Queries.GetAuditsStatus;
using ProductAuditSystem.Application.MappingProfiles;
using ProductAuditSystem.Application.UnitTests.Mocks;
using Shouldly;

namespace ProductAuditSystem.Application.UnitTests.Features.AuditStatus.Queries;

public class GetAuditStatusQueryHandlerTests
{
    private readonly Mock<IAuditStatusRepository> _mockRepo;
    private readonly IMapper _mapper;

    public GetAuditStatusQueryHandlerTests()
    {
        _mockRepo = MockAuditStatusRepository.GetMockAuditStatusRepository();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AuditStatusProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetAuditStatusListTest()
    {
        var handler = new GetAuditsStatusQueryHandler(_mapper, _mockRepo.Object);

        var result = await handler.Handle(new GetAuditsStatusQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<AuditStatusDTO>>();
        result.Count.ShouldBe(3);
    }
}
