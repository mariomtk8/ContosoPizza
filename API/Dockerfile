# Use the official .NET Core SDK as a parent image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the project file and restore any dependencies
COPY *.sln .
COPY Models/*.csproj Models/
COPY Services/*.csproj Services/
COPY Data/*.csproj Data/
COPY API/*.csproj API/
RUN dotnet restore 

# Copy the rest of the application code
COPY . .

# Publish the application (especificando directamente el proyecto)
RUN dotnet publish API/ContosoPizza.API.csproj -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expose the port your application will run on
#EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "ContosoPizza.API.dll"]