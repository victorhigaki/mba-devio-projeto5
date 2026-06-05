# Stage 1: Build environment
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source

# Copy and restore dependencies as distinct, cacheable layers
COPY *.csproj .
RUN dotnet restore

# Copy the remaining source code and publish the release
WORKDIR /source
COPY . .

WORKDIR /src/Coldmart.Alunos.API
RUN dotnet publish -c Release -o /app --no-restore

# Stage 2: Runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
EXPOSE 8080

# Copy the compiled binaries from the build stage
COPY --from=build /app .

# Define the entrypoint (replace 'YourApp' with your project's actual name)
ENTRYPOINT ["dotnet", "Coldmart.Alunos.API.dll"]
