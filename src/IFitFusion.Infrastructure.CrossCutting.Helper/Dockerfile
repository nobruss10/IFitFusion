#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/IFitFusion.Infrastructure.CrossCutting.Helper/IFitFusion.Infrastructure.CrossCutting.Helper.csproj", "src/IFitFusion.Infrastructure.CrossCutting.Helper/"]
RUN dotnet restore "src/IFitFusion.Infrastructure.CrossCutting.Helper/IFitFusion.Infrastructure.CrossCutting.Helper.csproj"
COPY . .
WORKDIR "/src/src/IFitFusion.Infrastructure.CrossCutting.Helper"
RUN dotnet build "IFitFusion.Infrastructure.CrossCutting.Helper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IFitFusion.Infrastructure.CrossCutting.Helper.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IFitFusion.Infrastructure.CrossCutting.Helper.dll"]