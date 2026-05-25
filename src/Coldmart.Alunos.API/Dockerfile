# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
# Install curl for health checks
RUN apt-get update && apt-get install -y curl
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
COPY ["src/Coldmart.Core/Coldmart.Core.csproj", "Coldmart.Core/"]
COPY ["src/Coldmart.Core.Data/Coldmart.Core.Data.csproj", "Coldmart.Core.Data/"]
COPY ["src/Coldmart.Auth.Data/Coldmart.Auth.Data.csproj", "Coldmart.Auth.Data/"]
COPY ["src/Coldmart.Alunos.Data/Coldmart.Alunos.Data.csproj", "Coldmart.Alunos.Data/"]
COPY ["src/Coldmart.Alunos.Domain/Coldmart.Alunos.Domain.csproj", "Coldmart.Alunos.Domain/"]
COPY ["src/Coldmart.Alunos.Business/Coldmart.Alunos.Business.csproj", "Coldmart.Alunos.Business/"]
COPY ["src/Coldmart.Alunos.API/Coldmart.Alunos.API.csproj", "Coldmart.Alunos.API/"]
RUN dotnet restore "Coldmart.Alunos.API/Coldmart.Alunos.API.csproj"
COPY . .
WORKDIR "/src/Coldmart.Alunos.API"
RUN dotnet build "./Coldmart.Alunos.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Coldmart.Alunos.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Coldmart.Alunos.API.dll"]
HEALTHCHECK --interval=5s --timeout=3s --start-period=2s --retries=3 CMD curl -f http://localhost:8080/healthz || exit 1