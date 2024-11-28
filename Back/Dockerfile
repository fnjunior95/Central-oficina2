# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar o arquivo de projeto e restaurar dependências
COPY WebApplication5/WebApplication5.csproj ./WebApplication5/
RUN dotnet restore ./WebApplication5/WebApplication5.csproj

# Copiar o restante do código e compilar a aplicação
COPY WebApplication5/ ./WebApplication5/
WORKDIR /app/WebApplication5
RUN dotnet publish -c Release -o out

# Estágio de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/WebApplication5/out ./
ENTRYPOINT ["dotnet", "WebApplication5.dll"]

# Expor a porta necessária
EXPOSE 80
