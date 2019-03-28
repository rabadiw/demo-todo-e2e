FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/Todo.Api/Todo.Api.csproj src/Todo.Api/
COPY src/Todo.Service/Todo.Service.csproj src/Todo.Service/
RUN dotnet restore src/Todo.Api/Todo.Api.csproj
COPY . .
WORKDIR /src/src/Todo.Api
RUN dotnet build Todo.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Todo.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Todo.Api.dll"]
