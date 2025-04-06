# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ECommerce.API/ECommerce.API.csproj", "src/ECommerce.API/"]
COPY ["src/Ecommerce.Application/Ecommerce.Application.csproj", "src/Ecommerce.Application/"]
COPY ["src/Ecommerce.Domain/Ecommerce.Domain.csproj", "src/Ecommerce.Domain/"]
COPY ["src/ECommerce.ReadModels/ECommerce.ReadModels.csproj", "src/ECommerce.ReadModels/"]
COPY ["src/ECommerce.Infra.ServiceBus/ECommerce.Infra.ServiceBus.csproj", "src/ECommerce.Infra.ServiceBus/"]
COPY ["src/ECommerce.Infra.CrossCutting.IoC/ECommerce.Infra.CrossCutting.IoC.csproj", "src/ECommerce.Infra.CrossCutting.IoC/"]
COPY ["src/ECommerce.Infra.Data/ECommerce.Infra.Data.csproj", "src/ECommerce.Infra.Data/"]
COPY ["src/ECommerce.Infra.Utils/ECommerce.Infra.Utils.csproj", "src/ECommerce.Infra.Utils/"]
RUN dotnet restore "./src/ECommerce.API/ECommerce.API.csproj"
COPY . .
WORKDIR "/src/src/ECommerce.API"
RUN dotnet build "./ECommerce.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ECommerce.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.API.dll"]