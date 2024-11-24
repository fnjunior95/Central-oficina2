# Utiliza a imagem do SDK do .NET para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos .csproj e restaura as dependências
COPY ./Back/Entrypoint/WebApi/WebApi.csproj ./entrypoint/WebApi/
RUN dotnet restore ./entrypoint/WebApi/WebApi.csproj

# Copia todos os outros arquivos e builda a aplicação
COPY ./Back/ .
RUN dotnet publish ./entrypoint/WebApi/WebApi.csproj -c Release -o out

# Utiliza a imagem runtime do .NET para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "WebApi.dll"]
