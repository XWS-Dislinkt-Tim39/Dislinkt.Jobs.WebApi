#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Dislinkt.Jobs.WebApi/Dislinkt.Jobs.WebApi.csproj", "Dislinkt.Jobs.WebApi/"]
COPY ["Dislinkt.Jobs.Application/Dislinkt.Jobs.Application.csproj", "Dislinkt.Jobs.Application/"]
COPY ["Dislinkt.Jobs.Core/Dislinkt.Jobs.Core.csproj", "Dislinkt.Jobs.Core/"]
COPY ["Dislinkt.Jobs.Domain/Dislinkt.Jobs.Domain.csproj", "Dislinkt.Jobs.Domain/"]
COPY ["Dislinkt.Jobs/Dislinkt.Jobs.csproj", "Dislinkt.Jobs/"]
COPY ["Dislinkt.Jobs.Persistance.MongoDB/Dislinkt.Jobs.Persistance.MongoDB.csproj", "Dislinkt.Jobs.Persistance.MongoDB/"]
RUN dotnet restore "Dislinkt.Jobs.WebApi/Dislinkt.Jobs.WebApi.csproj"
COPY . .
WORKDIR "/src/Dislinkt.Jobs.WebApi"
RUN dotnet build "Dislinkt.Jobs.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dislinkt.Jobs.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dislinkt.Jobs.WebApi.dll"]