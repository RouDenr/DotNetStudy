FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Bootcamp/d02/d02_ex00/d02_ex00.csproj", "Bootcamp/d02/d02_ex00/"]
RUN dotnet restore "Bootcamp/d02/d02_ex00/d02_ex00.csproj"
COPY . .
WORKDIR "/src/Bootcamp/d02/d02_ex00"
RUN dotnet build "d02_ex00.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "d02_ex00.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "d02_ex00.dll"]
