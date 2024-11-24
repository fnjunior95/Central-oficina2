FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app
COPY ./Oficina2/back/entrypoint/WebApi/WebApi.csproj ./WebApi/
RUN dotnet restore ./WebApi/WebApi.csproj
COPY ./Oficina2/back/entrypoint/WebApi/ ./WebApi/
RUN dotnet publish ./WebApi/WebApi.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "WebApi.dll"]
