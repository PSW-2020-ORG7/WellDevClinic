FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 51393

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["InterlayerController/InterlayerController.csproj", "InterlayerController/"]
RUN dotnet restore "InterlayerController/InterlayerController.csproj"
COPY . .
WORKDIR "/src/InterlayerController"
RUN dotnet build "InterlayerController.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InterlayerController.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InterlayerController.dll"]
