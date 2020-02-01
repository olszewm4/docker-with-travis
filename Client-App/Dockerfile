FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Client-App/Client-App.csproj", "Client-App/"]
RUN dotnet restore "Client-App/Client-App.csproj"
COPY . .
WORKDIR "/src/Client-App"
RUN dotnet build "Client-App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Client-App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Client-App.dll"]