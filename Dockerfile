FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

RUN useradd -u 8877 psw

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PSW_Web_app/PSW_Web_app.csproj", "PSW_Web_app/"]
COPY ["WellDevCore/WellDevCore.csproj", "WellDevCore/"]
RUN dotnet restore "PSW_Web_app/PSW_Web_app.csproj"
COPY . .
WORKDIR "/src/PSW_Web_app"
RUN dotnet build "PSW_Web_app.csproj" -c Release -o /app/build
WORKDIR /src

FROM build AS publish
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef --version 3.1.9
WORKDIR "/src/PSW_Web_app"
RUN dotnet publish "PSW_Web_app.csproj" -c Release -o /app/publish 
WORKDIR /src
RUN dotnet-ef migrations script -p "PSW_Web_app/PSW_Web_app.csproj" -o /app/sql/init.sql

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
WORKDIR /app/publish
VOLUME /app/sql
CMD ASPNETCORE_URLS=http://*:49153 dotnet PSW_Web_app.dll

USER psw





