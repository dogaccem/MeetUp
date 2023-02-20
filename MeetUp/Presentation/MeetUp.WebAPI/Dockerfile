#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/MeetUp.WebAPI/MeetUp.WebAPI.csproj", "Presentation/MeetUp.WebAPI/"]
COPY ["Core/MeetUp.Application/MeetUp.Application.csproj", "Core/MeetUp.Application/"]
COPY ["Core/MeetUp.Domain/MeetUp.Domain.csproj", "Core/MeetUp.Domain/"]
COPY ["Infrastructure/MeetUp.Infrastructure/MeetUp.Infrastructure.csproj", "Infrastructure/MeetUp.Infrastructure/"]
COPY ["Infrastructure/MeetUp.Persistence/MeetUp.Persistence.csproj", "Infrastructure/MeetUp.Persistence/"]
RUN dotnet restore "Presentation/MeetUp.WebAPI/MeetUp.WebAPI.csproj"
COPY . .
WORKDIR "/src/Presentation/MeetUp.WebAPI"
RUN dotnet build "MeetUp.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MeetUp.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeetUp.WebAPI.dll"]