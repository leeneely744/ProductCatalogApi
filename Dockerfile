FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /src
COPY ProductCatalogApi.csproj .
RUN dotnet restore "ProductCatalogApi.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "ProductCatalogApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductCatalogApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductCatalogApi.dll"]
