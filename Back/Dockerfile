FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ./Back/Entrypoint/WebApi/WebApi.csproj ./Back/Entrypoint/WebApi/
RUN dotnet restore ./Back/Entrypoint/WebApi/WebApi.cspro

COPY ./ . 
RUN dotnet publish ./Back/Entrypoint/WebApi/WebApi.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "WebApi.dll"]
