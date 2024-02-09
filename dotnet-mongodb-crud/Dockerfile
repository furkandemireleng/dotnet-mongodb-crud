FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["dotnet-mongodb-crud/dotnet-mongodb-crud.csproj", "dotnet-mongodb-crud/"]
RUN dotnet restore "dotnet-mongodb-crud/dotnet-mongodb-crud.csproj"
COPY . .
WORKDIR "/src/dotnet-mongodb-crud"
RUN dotnet build "dotnet-mongodb-crud.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnet-mongodb-crud.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnet-mongodb-crud.dll"]
