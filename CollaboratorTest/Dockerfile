# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos do projeto
COPY . ./

# Restaura as dependências do projeto
RUN dotnet restore

# Compila o projeto
RUN dotnet publish -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia os arquivos do build para o runtime
COPY --from=build /out .

# Expõe a porta da aplicação
EXPOSE 80
EXPOSE 443

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "CollaboratorTest.dll"]
