FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 49153
ENV ASPNETCORE_URLS=http://*:49153

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . PSW_Web_app/
RUN dotnet restore "PSW_Web_app/PSW_Web_app.csproj"
COPY . .
WORKDIR "/src/PSW_Web_app"
RUN dotnet build "PSW_Web_app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PSW_Web_app.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PSW_Web_app.dll"]
