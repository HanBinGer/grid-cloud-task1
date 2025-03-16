# grid-cloud-task-1
Сбилдить и запустить контейнер командной:

    docker compose -f ".\docker-compose.yml" -f ".\docker-compose.override.yml" --ansi never up -d --build --remove-orphans

Swagger:

    http://localhost:8080/swagger/index.html
    https://localhost:8081/swagger/index.html