# Dockerfile

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY /Backend/Backend.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY /Backend .
RUN dotnet publish -c Release -o out

EXPOSE 80/tcp

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
 
# Run the app on container startup
# Use your project name for the second parameter
# e.g. MyProject.dll
ENTRYPOINT [ "dotnet", "Backend.dll" ]
