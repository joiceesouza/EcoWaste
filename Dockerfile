# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia os arquivos de solução e projetos para restaurar as dependências
COPY *.sln .
COPY EcoWaste.Api/*.csproj ./EcoWaste.Api/
COPY EcoWaste.Business/*.csproj ./EcoWaste.Business/
COPY EcoWaste.Core/*.csproj ./EcoWaste.Core/
COPY EcoWaste.DataAccess/*.csproj ./EcoWaste.DataAccess/

# Cria as pastas necessárias e restaura dependências
RUN mkdir -p EcoWaste.Api EcoWaste.Business EcoWaste.Core EcoWaste.DataAccess
RUN dotnet restore EcoWaste.Api/EcoWaste.Api.csproj

# Copia o restante dos arquivos do projeto
COPY . .

# Publica a aplicação
WORKDIR /src/EcoWaste.Api
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expõe a porta padrão HTTP
EXPOSE 80

# Comando de entrada
ENTRYPOINT ["dotnet", "EcoWaste.Api.dll"]