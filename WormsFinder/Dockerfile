FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WormsFinder/WormsFinder.csproj", "WormsFinder/"]
RUN dotnet restore "WormsFinder/WormsFinder.csproj"
COPY . .
WORKDIR "/src/WormsFinder"
RUN dotnet build "WormsFinder.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WormsFinder.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WormsFinder.dll"]
