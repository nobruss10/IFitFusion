#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FitFusion.Infrastructure.Data/FitFusion.Infrastructure.Data.csproj", "FitFusion.Infrastructure.Data/"]
RUN dotnet restore "FitFusion.Infrastructure.Data/FitFusion.Infrastructure.Data.csproj"

COPY ["IFitFusion.Application/IFitFusion.Application.csproj", "IFitFusion.Application/"]
RUN dotnet restore "IFitFusion.Application/IFitFusion.Application.csproj"

COPY ["IFitFusion.Domain/IFitFusion.Domain.csproj", "IFitFusion.Domain/"]
RUN dotnet restore "IFitFusion.Domain/IFitFusion.Domain.csproj"

COPY ["IFitFusion.Infrastructure.CrossCutting.DomainHelpe/IFitFusion.Infrastructure.CrossCutting.DomainHelper.csproj", "IFitFusion.Infrastructure.CrossCutting.DomainHelpe/"]
RUN dotnet restore "IFitFusion.Infrastructure.CrossCutting.DomainHelpe/IFitFusion.Infrastructure.CrossCutting.DomainHelper.csproj"

COPY ["IFitFusion.Infrastructure.CrossCutting.Helpers/IFitFusion.Infrastructure.CrossCutting.Helpers.csproj", "IFitFusion.Infrastructure.CrossCutting.Helpers"]
RUN dotnet restore "IFitFusion.Infrastructure.CrossCutting.Helpers/IFitFusion.Infrastructure.CrossCutting.Helpers.csproj"

COPY ["IFitFusion.Infrastructure.CrossCutting.IoC/IFitFusion.Infrastructure.CrossCutting.IoC.csproj", "IFitFusion.Infrastructure.CrossCutting.IoC/"]
RUN dotnet restore "IFitFusion.Infrastructure.CrossCutting.IoC/IFitFusion.Infrastructure.CrossCutting.IoC.csproj"


COPY ["IFitFusion.Service.Api/IFitFusion.Service.Api.csproj", "IFitFusion.Service.Api/"]
RUN dotnet restore "IFitFusion.Service.Api/IFitFusion.Service.Api.csproj"
COPY . .
WORKDIR "/src/IFitFusion.Service.Api"
RUN dotnet build "IFitFusion.Service.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IFitFusion.Service.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IFitFusion.Service.Api.dll"]