FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["SafeRoomApp/SafeRoomApp.csproj", "SafeRoomApp/"]
RUN dotnet restore "SafeRoomApp/SafeRoomApp.csproj"
COPY . .
WORKDIR "/src/SafeRoomApp"
RUN dotnet build "SafeRoomApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SafeRoomApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SafeRoomApp.dll"]