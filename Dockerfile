# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiamos csproj y restauramos dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiamos el resto del proyecto y build
COPY . ./
RUN dotnet publish -c Release -o /out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out ./

# Exponemos puertos
EXPOSE 5000
EXPOSE 5001

# Comando para correr la app
ENTRYPOINT ["dotnet", "base_project.dll"]
