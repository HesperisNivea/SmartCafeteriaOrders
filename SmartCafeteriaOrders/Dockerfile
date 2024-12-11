
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
# Copy project files
COPY ["SmartCafeteriaOrders.sln", "."]
COPY ["SmartCafeteriaOrders.Repository/SmartCafeteriaOrders.Repository.csproj", "SmartCafeteriaOrders.Repository/"]
COPY ["SmartCafeteriaOrders/SmartCafeteriaOrders.csproj", "SmartCafeteriaOrders/"]

# Restore dependencies
RUN dotnet restore "SmartCafeteriaOrders/SmartCafeteriaOrders.csproj"

# Copy the full solution
COPY . .

# Build all projects
RUN dotnet build "SmartCafeteriaOrders/SmartCafeteriaOrders.csproj" -c Release

# Stage 2: Publish the application
FROM build AS publish
WORKDIR /src/SmartCafeteriaOrders
RUN dotnet publish "SmartCafeteriaOrders.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartCafeteriaOrders.dll"]