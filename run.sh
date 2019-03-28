export APPDATA=/tmp/todo/

docker-compose  \
  -f "docker-compose.yml" \
  -f "docker-compose.override.yml" \
  -p tododemo \
  --no-ansi \
  up \
  --build --force-recreate --remove-orphans
  -d \
