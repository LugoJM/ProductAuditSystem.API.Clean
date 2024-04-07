#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ProductAuditSystem.API/ProductAuditSystem.API.csproj", "ProductAuditSystem.API/"]
COPY ["ProductAuditSystem.Application/ProductAuditSystem.Application.csproj", "ProductAuditSystem.Application/"]
COPY ["ProductAuditSystem.Domain/ProductAuditSystem.Domain.csproj", "ProductAuditSystem.Domain/"]
COPY ["ProductAuditSystem.Infrastructure/ProductAuditSystem.Infrastructure.csproj", "ProductAuditSystem.Infrastructure/"]
COPY ["ProductAuditSystem.Persistence/ProductAuditSystem.Persistence.csproj", "ProductAuditSystem.Persistence/"]
RUN dotnet restore "ProductAuditSystem.API/ProductAuditSystem.API.csproj"
COPY . .
WORKDIR "/src/ProductAuditSystem.API"
RUN dotnet build "ProductAuditSystem.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductAuditSystem.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductAuditSystem.API.dll"]