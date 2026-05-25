# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
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
COPY ["src/Coldmart.Pagamentos.Domain/Coldmart.Pagamentos.Domain.csproj", "Coldmart.Pagamentos.Domain/"]
COPY ["src/Coldmart.Pagamentos.Data/Coldmart.Pagamentos.Data.csproj", "Coldmart.Pagamentos.Data/"]
COPY ["src/Coldmart.Pagamentos.Business/Coldmart.Pagamentos.Business.csproj", "Coldmart.Pagamentos.Business/"]
COPY ["src/Coldmart.Pagamentos.API/Coldmart.Pagamentos.API.csproj", "Coldmart.Pagamentos.API/"]
COPY ["src/Coldmart.BFF/Coldmart.BFF.csproj", "Coldmart.BFF/"]
RUN dotnet restore "Coldmart.BFF/Coldmart.BFF.csproj"
COPY . .
WORKDIR "/src/Coldmart.BFF"
RUN dotnet build "./Coldmart.BFF.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Coldmart.BFF.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Coldmart.BFF.dll"]
