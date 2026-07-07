# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY BLOG.API/BLOG.API.csproj BLOG.API/
RUN dotnet restore BLOG.API/BLOG.API.csproj

# Copy the remaining source code
COPY . .

# Build and publish
WORKDIR /src/BLOG.API
RUN dotnet publish BLOG.API.csproj -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "BLOG.API.dll"]