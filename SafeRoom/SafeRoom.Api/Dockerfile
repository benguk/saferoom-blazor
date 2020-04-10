FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["SafeRoom.Api/SafeRoom.Api.csproj", "SafeRoom.Api/"]
RUN dotnet restore "SafeRoom.Api/SafeRoom.Api.csproj"
COPY . .
WORKDIR "/src/SafeRoom.Api"
RUN dotnet build "SafeRoom.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SafeRoom.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SafeRoom.Api.dll"]