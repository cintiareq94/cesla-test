# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the solution and project files
COPY CeslaTest.sln ./ 
COPY Api/Api.csproj Api/
COPY Application/Application.csproj Application/
COPY Domain/Domain.csproj Domain/
COPY CrossCutting/CrossCutting.csproj Infrastructure/CrossCutting/
COPY Data/Data.csproj Infrastructure/Data/

# Restore dependencies
RUN dotnet restore ./Api/Api.csproj

# Copy all project files and publish the API project
COPY . ./
RUN dotnet publish ./Api/Api.csproj -c Release -o /out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the build output to the runtime image
COPY --from=build /out .

# Expose application ports
EXPOSE 80
EXPOSE 443

# Command to start the application
ENTRYPOINT ["dotnet", "Api.dll"]
