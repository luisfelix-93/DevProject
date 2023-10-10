#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DevProject/DevProject.csproj", "DevProject/"]
RUN dotnet restore "DevProject/DevProject.csproj"
COPY . .
WORKDIR "/src/DevProject"
RUN dotnet build "DevProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevProject.dll"]