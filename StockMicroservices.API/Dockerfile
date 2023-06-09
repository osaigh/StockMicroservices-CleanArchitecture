#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StockMicroservices.API/StockMicroservices.API.csproj", "StockMicroservices.API/"]
COPY ["StockMicroservices.Application/StockMicroservices.Application.csproj", "StockMicroservices.Application/"]
COPY ["StockMicroservices.Domain/StockMicroservices.Domain.csproj", "StockMicroservices.Domain/"]
COPY ["StockMicroservices.Abstractions/StockMicroservices.Abstractions.csproj", "StockMicroservices.Abstractions/"]
COPY ["StockMicroservices.EventBus.Common/StockMicroservices.EventBus.Common.csproj", "StockMicroservices.EventBus.Common/"]
COPY ["StockMicroservices.Infrastructure/StockMicroservices.Infrastructure.csproj", "StockMicroservices.Infrastructure/"]
RUN dotnet restore "StockMicroservices.API/StockMicroservices.API.csproj"
COPY . .
WORKDIR "/src/StockMicroservices.API"
RUN dotnet build "StockMicroservices.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StockMicroservices.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockMicroservices.API.dll"]
