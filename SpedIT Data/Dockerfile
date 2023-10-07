#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SpedIT Data/SpedIT Data.csproj", "SpedIT Data/"]
RUN dotnet restore "SpedIT Data/SpedIT Data.csproj"
COPY . .
WORKDIR "/src/SpedIT Data"
RUN dotnet build "SpedIT Data.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpedIT Data.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpedIT Data.dll"]