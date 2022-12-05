#!/bin/sh

tag="latest"
net_version="7.0"
context=$(pwd)
dockerfiles=(`find . -name Dockerfile`)

for dockerfile in "${dockerfiles[@]}"
do
    parentDir=$(basename $(dirname "$dockerfile"))
    parentDir=${parentDir//./-}
    parentDir="$(tr [A-Z] [a-z] <<< "$parentDir")"

    docker build \
        --tag "hermes/$parentDir:$tag" \
        --build-arg NET_VERSION="$net_version" \
        --build-arg CONFIGURATION=Debug \
        --file "$dockerfile" \
        "$context"
done
