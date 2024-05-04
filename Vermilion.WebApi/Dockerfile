
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Vermilion.WebApi/Vermilion.WebApi.csproj", "Vermilion.WebApi/"]
COPY ["Vermilion.Application/Vermilion.Application.csproj", "Vermilion.Application/"]
COPY ["Vermilion.Contracts/Vermilion.Contracts.csproj", "Vermilion.Contracts/"]
COPY ["Vermilion.Domain/Vermilion.Domain.csproj", "Vermilion.Domain/"]
COPY ["Vermilion.Infrastructure/Vermilion.Infrastructure.csproj", "Vermilion.Infrastructure/"]
RUN dotnet restore "./Vermilion.WebApi/./Vermilion.WebApi.csproj"
COPY . .
WORKDIR "/src/Vermilion.WebApi"
RUN dotnet build "./Vermilion.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Vermilion.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vermilion.WebApi.dll"]