FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["TariffComparison.API/TariffComparison.API.csproj", "TariffComparison.API/"]
COPY ["TariffComparison.Data.Mock/TariffComparison.Data.Mock.csproj", "TariffComparison.Data.Mock/"]
COPY ["TariffComparison.Domain/TariffComparison.Domain.csproj", "TariffComparison.Domain/"]

COPY ["TariffComparison.API.Tests/TariffComparison.API.Tests.csproj", "TariffComparison.API.Tests/"]
COPY ["TariffComparison.Domain.Tests/TariffComparison.Domain.Tests.csproj", "TariffComparison.Domain.Tests/"]

RUN dotnet restore "TariffComparison.API/TariffComparison.API.csproj"
RUN dotnet restore "TariffComparison.API.Tests/TariffComparison.API.Tests.csproj"
RUN dotnet restore "TariffComparison.Domain.Tests/TariffComparison.Domain.Tests.csproj"

COPY . .
WORKDIR "/src/TariffComparison.API"
RUN dotnet build "TariffComparison.API.csproj" -c Release -o /app/build

WORKDIR "/src/TariffComparison.API.Tests"
RUN dotnet test --no-restore --verbosity normal

WORKDIR "/src/TariffComparison.Domain.Tests"
RUN dotnet test --no-restore --verbosity normal

FROM build AS publish
WORKDIR /src/TariffComparison.API
RUN dotnet publish "TariffComparison.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TariffComparison.API.dll"]