FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 59518
EXPOSE 44364

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY api.livraria.auth/api.livraria.auth.csproj api.livraria.auth.docker/
RUN dotnet restore api.livraria.auth.docker/api.livraria.auth.docker.csproj
COPY . .
WORKDIR /src/api.livraria.auth.docker
RUN dotnet build api.livraria.auth.docker.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish api.livraria.auth.docker.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "api.livraria.auth.docker.dll"]
