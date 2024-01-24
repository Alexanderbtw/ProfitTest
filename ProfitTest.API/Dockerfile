FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProfitTest.API/ProfitTest.API.csproj", "ProfitTest.API/"]
COPY ["ProfitTest.Application/ProfitTest.Application.csproj", "ProfitTest.Application/"]
COPY ["ProfitTest.Core/ProfitTest.Core.csproj", "ProfitTest.Core/"]
COPY ["ProfitTest.DAL/ProfitTest.DAL.csproj", "ProfitTest.DAL/"]
RUN dotnet restore "./ProfitTest.API/./ProfitTest.API.csproj"
COPY . .
WORKDIR "/src/ProfitTest.API"
RUN dotnet build "./ProfitTest.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProfitTest.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProfitTest.API.dll"]