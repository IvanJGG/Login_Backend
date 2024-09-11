# Usa una imagen oficial de .NET como base
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Usa una imagen oficial de .NET SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Login.csproj", "./"]
RUN dotnet restore "Login.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Login.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Login.csproj" -c Release -o /app/publish

# Usa la imagen base para ejecutar la aplicación
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Login.dll"]
