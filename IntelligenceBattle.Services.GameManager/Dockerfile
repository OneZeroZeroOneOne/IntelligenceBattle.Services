FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /source

COPY IntelligenceBattle.Services.GameManager/*.csproj IntelligenceBattle.Services.GameManager/

RUN dotnet restore IntelligenceBattle.Services.GameManager/IntelligenceBattle.Services.GameManager.csproj

COPY IntelligenceBattle.Services.GameManager/ IntelligenceBattle.Services.GameManager/
WORKDIR /source/IntelligenceBattle.Services.GameManager
RUN dotnet build -c release

FROM build AS publish
RUN dotnet publish -c release --no-build -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "IntelligenceBattle.Services.GameManager.dll"]