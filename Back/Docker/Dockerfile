
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


COPY ./Back/OficinaELLP.sln ./ 
COPY ./Back/Entrypoint/WebApi/WebApi.csproj ./Entrypoint/WebApi/
RUN dotnet restore ./OficinaELLP.sln


COPY ./Back/ . 
RUN dotnet publish ./Entrypoint/WebApi/WebApi.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "WebApi.dll"]

