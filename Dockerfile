#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ceabs/Ceabs.csproj", "Ceabs/"]
COPY ["CEABS.Service/CEABS.Service.csproj", "CEABS.Service/"]
COPY ["CEABS.Infrastructure/CEABS.Infrastructure.csproj", "CEABS.Infrastructure/"]
COPY ["CEABS.Domain/CEABS.Domain.csproj", "CEABS.Domain/"]
RUN dotnet restore "Ceabs/Ceabs.csproj"
COPY . .
WORKDIR "/src/Ceabs"
RUN dotnet build "Ceabs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ceabs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ceabs.dll"]
