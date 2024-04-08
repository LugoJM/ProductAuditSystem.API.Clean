using AutoMapper;
using Moq;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Features.AuditStatus.Queries.GetAuditStatus;
using ProductAuditSystem.Application.MappingProfiles;
using ProductAuditSystem.Application.UnitTests.Mocks;
using Shouldly;

namespace ProductAuditSystem.Application.UnitTests.Features.AuditStatus.Queries;

public class GetAuditStatusQueryHandlerTest
{
    private readonly Mock<IAuditStatusRepository> _mock;
    private readonly IMapper _mapper;
    public GetAuditStatusQueryHandlerTest()
    {
        _mock = MockAuditStatusRepository.GetMockAuditStatusRepository();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AuditStatusProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetAuditByIdTest()
    {
        const int AuditStatusID = 1;

        var handler = new GetAuditStatusQueryHandler(_mapper, _mock.Object);

        var result = await handler.Handle(new GetAuditStatusQuery(AuditStatusID), CancellationToken.None);

        result.ShouldNotBeNull();
    }
}
