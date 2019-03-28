### Enable TLS in Docker
```bash
# cmd to generate a development certificate
dotnet dev-certs https --trust
# cmd to export a cert with password for use within Docker container
dotnet dev-certs https -v -ep <path/to/localhost.pfx> -p <password to use>
```

Once the cert was created, add the following environment variables to your `docker-compose.yml` file.
```yml
# example
services:
  app:
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ASPNETCORE_URLS=https://+:443;http://+:80
      - ASPNETCORE_HTTPS_PORT=44365
      - Kestrel__Certificates__Default__PASSWORD=apples
      - Kestrel__Certificates__Default__PATH=/root/.aspnet/https/localhost.pfx
    ports:
      - "49167:80"
      - "44365:443"
    volumes:
      - ${APPDATA}/ASP.NET/Https:/root/.aspnet/https:ro
      - ${APPDATA}/Microsoft/UserSecrets:/root/.microsoft/usersecrets:ro
```