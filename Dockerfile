# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj first (for better caching)
COPY TinyBoard.Web/TinyBoard.Web.csproj TinyBoard.Web/
RUN dotnet restore TinyBoard.Web/TinyBoard.Web.csproj

# Copy everything else and publish
COPY . .
RUN dotnet publish TinyBoard.Web/TinyBoard.Web.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "TinyBoard.Web.dll"]