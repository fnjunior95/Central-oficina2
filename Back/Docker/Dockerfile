# Utiliza a imagem do SDK do .NET para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia o arquivo .sln e restaura as dependências
COPY ./Back/OficinaELLP.sln ./ 
COPY ./Back/Entrypoint/WebApi/WebApi.csproj ./Entrypoint/WebApi/
RUN dotnet restore ./OficinaELLP.sln

# Copia todos os outros arquivos da solução e builda a aplicação
COPY ./Back/ . 
RUN dotnet publish ./Entrypoint/WebApi/WebApi.csproj -c Release -o /app/out

# Utiliza a imagem runtime do .NET para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "WebApi.dll"]

