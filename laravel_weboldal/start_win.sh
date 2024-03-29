#!/bin/sh -e

COMPOSE="docker compose"

if ! $($COMPOSE 2>/dev/null); then
    COMPOSE="docker-compose"
fi

if [ -f ".env" ]; then
    echo ".env fájl már létezik!"
else 
    cp .env.example .env
fi

if [ "$1" ]; then
  MODE=$1
else
  MODE=dev
fi

# shopt -s expand_aliases

winpty $COMPOSE -f docker-compose.yml -f docker-compose.$MODE.yml  up -d
winpty $COMPOSE exec app composer install
winpty $COMPOSE exec app php artisan key:generate
winpty $COMPOSE exec app npm install
winpty $COMPOSE exec app php artisan migrate:refresh
winpty $COMPOSE exec app php artisan db:seed
winpty $COMPOSE exec app php artisan storage:link
winpty $COMPOSE exec app npm run build
winpty $COMPOSE exec app npm run dev