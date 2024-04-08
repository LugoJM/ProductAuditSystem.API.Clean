using Microsoft.EntityFrameworkCore;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Persistence.DataBaseContext;
using Shouldly;

namespace ProductAuditSystem.Persistence.IntegrationTests;

public class ProductAuditSystemDBContextTests
{
    private readonly ProductAuditSystemDBContext _productAuditSystemDBContext;

    public ProductAuditSystemDBContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<ProductAuditSystemDBContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _productAuditSystemDBContext = new ProductAuditSystemDBContext(dbOptions);
    }

    [Fact]
    public async Task Save_DateCreatedAtValueAsync()
    {
        var auditStatus = new AuditStatus
        {
            Id = 1,
            Status = "In-Process"
        };

        await _productAuditSystemDBContext.AuditStatus.AddAsync(auditStatus);
        await _productAuditSystemDBContext.SaveChangesAsync();

        auditStatus.FechaCreacion.ShouldNotBeNull();
    }

    [Fact]
    public async void Save_DateModifiedAtValue()
    {
        var auditStatus = new AuditStatus
        {
            Id = 1,
            Status = "In-Process"
        };

        await _productAuditSystemDBContext.AuditStatus.AddAsync(auditStatus);
        await _productAuditSystemDBContext.SaveChangesAsync();

        auditStatus.FechaModificacion.ShouldNotBeNull();
    }
}
