# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos de projeto e restaura as dependências
COPY *.sln .
COPY EcoWaste.Api/*.csproj ./EcoWaste.Api/
COPY EcoWaste.Business/*.csproj ./EcoWaste.Business/
COPY EcoWaste.Core/*.csproj ./EcoWaste.Core/
COPY EcoWaste.DataAccess/*.csproj ./EcoWaste.DataAccess/

# Criação de diretórios (opcional, garante que existam)
RUN mkdir -p EcoWaste.Api EcoWaste.Business EcoWaste.Core EcoWaste.DataAccess

RUN dotnet restore

# Copia o restante dos arquivos
COPY . .

# Publica a aplicação
WORKDIR /src/EcoWaste.Api
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expõe a porta padrão HTTP
EXPOSE 80

# Comando de entrada
ENTRYPOINT ["dotnet", "EcoWaste.Api.dll"]