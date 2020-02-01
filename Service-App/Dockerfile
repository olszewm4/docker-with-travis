FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Service-App/Service-App.csproj", "Service-App/"]
COPY ["Db-Service/Db-Service.csproj", "Db-Service/"]
RUN dotnet restore "Service-App/Service-App.csproj"
COPY . .
WORKDIR "/src/Service-App"
RUN dotnet build "Service-App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Service-App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Service-App.dll"]