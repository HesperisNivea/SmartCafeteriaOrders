FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SmartCafeteriaOrders.sln", "."]
COPY ["SmartCafeteriaOrders/SmartCafeteriaOrders.csproj", "SmartCafeteriaOrders/"]
RUN dotnet restore "SmartCafeteriaOrders/SmartCafeteriaOrders.csproj"
COPY . .
WORKDIR "/src/SmartCafeteriaOrders"
RUN dotnet build "SmartCafeteriaOrders.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SmartCafeteriaOrders.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartCafeteriaOrders.dll"]
