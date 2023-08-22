#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY src/FitFusion.Infrastructure.Data/FitFusion.Infrastructure.Data.csproj src/FitFusion.Infrastructure.Data/FitFusion.Infrastructure.Data.csproj
COPY src/IFitFusion.Application/IFitFusion.Application.csproj src/IFitFusion.Application/IFitFusion.Application.csproj
COPY src/IFitFusion.Domain/IFitFusion.Domain.csproj src/IFitFusion.Domain/IFitFusion.Domain.csproj
COPY src/IFitFusion.Infrastructure.CrossCutting.DomainHelpe/IFitFusion.Infrastructure.CrossCutting.DomainHelper.csproj src/IFitFusion.Infrastructure.CrossCutting.DomainHelpe/IFitFusion.Infrastructure.CrossCutting.DomainHelper.csproj
COPY src/IFitFusion.Infrastructure.CrossCutting.Helpers/IFitFusion.Infrastructure.CrossCutting.Helpers.csproj src/IFitFusion.Infrastructure.CrossCutting.Helpers/IFitFusion.Infrastructure.CrossCutting.Helpers.csproj
COPY src/IFitFusion.Infrastructure.CrossCutting.IoC/IFitFusion.Infrastructure.CrossCutting.IoC.csproj src/IFitFusion.Infrastructure.CrossCutting.IoC/IFitFusion.Infrastructure.CrossCutting.IoC.csproj



COPY ["src/IFitFusion.Service.Api/IFitFusion.Service.Api.csproj", "src/IFitFusion.Service.Api/"]
RUN dotnet restore "src/IFitFusion.Service.Api/IFitFusion.Service.Api.csproj"
COPY . .
WORKDIR "/src/src/IFitFusion.Service.Api"
RUN dotnet build "IFitFusion.Service.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IFitFusion.Service.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IFitFusion.Service.Api.dll"]