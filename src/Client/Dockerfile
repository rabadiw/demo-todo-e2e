FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/Client/Client.csproj src/Client/
RUN dotnet restore src/Client/Client.csproj
COPY . .
WORKDIR /src/src/Client
RUN dotnet build Client.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Client.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Client.dll"]
