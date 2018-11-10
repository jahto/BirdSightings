FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 29327
EXPOSE 44395

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["BirdSightings/BirdSightings.csproj", "BirdSightings/"]
RUN dotnet restore "BirdSightings/BirdSightings.csproj"
COPY . .
WORKDIR "/src/BirdSightings"
RUN dotnet build "BirdSightings.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BirdSightings.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BirdSightings.dll"]