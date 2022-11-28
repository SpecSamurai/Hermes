#!/bin/sh

net_version="7.0"
context=$(pwd)
dockerfiles=(`find . -name Dockerfile`)

for dockerfile in "${dockerfiles[@]}"
do
    docker build \
        --tag hermes/catalog-api:latest \
        --build-arg NET_VERSION="$net_version" \
        --build-arg CONFIGURATION=Debug \
        --file "$dockerfile" \
        "$context"
done
