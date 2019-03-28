docker-compose  \
  -f "docker-compose.yml" \
  -f "docker-compose.override.yml" \
  -p tododemo \
  --no-ansi \
  down

# clean up docker
docker rmi $(docker images | grep "none" | awk '{print $3}')