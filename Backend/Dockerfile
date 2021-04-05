# Dockerfile

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY Backend.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o out

EXPOSE 80/tcp

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
COPY .env .
# Run the app on container startup
# Use your project name for the second parameter
# e.g. MyProject.dll
ENTRYPOINT [ "dotnet", "Backend.dll" ]
#This allows the our container to use the Heroku-provided port on startup.
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Backend.dll
