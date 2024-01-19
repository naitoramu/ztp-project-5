#!/bin/bash

docker rm ztp-project-5-eshop.api-1
docker rmi eshopapi:latest
docker compose up --force-recreate