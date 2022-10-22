FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env



# Copy csproj and restore as distinct layers
COPY BookStore.sln ./
COPY BookStore.csproj ./

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish BookStore.sln -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

ENV ASPNETCORE_URLS=http://*:8080
ENV ASPNETCORE_ENVIRONMENT=Development

USER 1000

WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "BookStore.dll"]