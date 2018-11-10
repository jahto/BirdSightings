FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 29327
EXPOSE 44395

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["./BirdSightings.csproj", "BirdSightings/"]
RUN dotnet restore "BirdSightings/BirdSightings.csproj"
COPY . "BirdSightings/"
WORKDIR "/src/BirdSightings"
RUN dotnet build "BirdSightings.csproj" -c Release -o /app

FROM build AS publish
# Setup node
ENV NODE_VERSION 10.13.0
ENV NODE_DOWNLOAD_SHA b4b5d8f73148dcf277df413bb16827be476f4fa117cbbec2aaabc8cc0a8588e1

RUN curl -SL "https://nodejs.org/dist/v${NODE_VERSION}/node-v${NODE_VERSION}-linux-x64.tar.gz" \
         --output nodejs.tar.gz \
    && echo "$NODE_DOWNLOAD_SHA nodejs.tar.gz" | sha256sum -c - \
    && tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \
    && rm nodejs.tar.gz \
    && ln -s /usr/local/bin/node /usr/local/bin/nodejs\
    && npm i -g @angular/cli npm i -g @angular/cli

RUN dotnet publish "BirdSightings.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BirdSightings.dll"]
