# =======================
# Stage 1: Build
# =======================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copia os arquivos de projeto e restaura dependências
COPY *.sln .
COPY EcoWaste.Api/*.csproj ./EcoWaste.Api/
COPY EcoWaste.Business/*.csproj ./EcoWaste.Business/
COPY EcoWaste.Core/*.csproj ./EcoWaste.Core/
COPY EcoWaste.DataAccess/*.csproj ./EcoWaste.DataAccess/

RUN dotnet restore

# Copia todo o código e publica em Release
COPY . .
RUN dotnet publish EcoWaste.Api -c Release -o /app/out

# =======================
# Stage 2: Runtime
# =======================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app
COPY --from=build /app/out .

# Expõe a porta da aplicação
EXPOSE 8080

# Garante que o Swagger e a API escutem em todas as interfaces
ENV ASPNETCORE_URLS=http://+:8080

# Entry point
ENTRYPOINT ["dotnet", "EcoWaste.Api.dll"]
