FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Bootcamp/d_00/d_00.csproj", "Bootcamp/d_00/"]
RUN dotnet restore "Bootcamp/d_00/d_00.csproj"
COPY . .
WORKDIR "/src/Bootcamp/d_00"
RUN dotnet build "d_00.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "d_00.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "d_00.dll"]
