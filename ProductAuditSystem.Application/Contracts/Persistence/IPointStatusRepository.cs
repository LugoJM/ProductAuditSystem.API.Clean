﻿
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Contracts.Persistence;

public interface IPointStatusRepository : IGenericRepository<PointStatus>
{
    Task<PointStatus?> FindPointStatus(string status);
}
