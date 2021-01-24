FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 61089

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Examination_Interlayer/Examination_Interlayer.csproj", "Examination_Interlayer/"]
COPY ["Examination_Microservice/Examination_Microservice.csproj", "Examination_Microservice/"]
COPY ["EventSourcing/EventSourcing.csproj", "EventSourcing/"]
COPY ["Examination_Interlayer/DBScript.txt" , "Examination_Interlayer/DBScript.txt"]

RUN dotnet restore "Examination_Interlayer/Examination_Interlayer.csproj"
COPY . .
WORKDIR "/src/Examination_Interlayer"
RUN dotnet build "Examination_Interlayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Examination_Interlayer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:61089 dotnet Examination_Interlayer.dll


