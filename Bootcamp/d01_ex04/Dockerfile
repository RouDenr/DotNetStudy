FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Bootcamp/d01_ex04/d01_ex04.csproj", "Bootcamp/d01_ex04/"]
RUN dotnet restore "Bootcamp/d01_ex04/d01_ex04.csproj"
COPY . .
WORKDIR "/src/Bootcamp/d01_ex04"
RUN dotnet build "d01_ex04.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "d01_ex04.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "d01_ex04.dll"]
