# E-commerce project based on a microservices architecture

# Development and deployment
## Application settings and environmental variables
### Catalog API
- ASPNETCORE_ENVIRONMENT=[Development|Production]
- ConnectionStrings__CatalogContext
- BusOptions__Host
- BusOptions__Username
- BusOptions__Password
- BusOptions__LicensePath

### Basket API
- ASPNETCORE_ENVIRONMENT=[Development|Production]
- ConnectionStrings__BasketDatabase

## Useful commands
- `dotnet ef migrations add Initial --output-dir ./Migrations`
- `dotnet ef database update`

- `docker build --build-arg NET_VERSION=6.0 --build-arg CONFIGURATION=release -f Dockerfile ../../../`
- `docker rmi $(docker images -aq)`

- `kubectl apply -f ./k8s --recursive`
- `kubectl apply -f ./k8s/configmap/catalog-api.dev.yaml -f ./k8s/deployment --recursive`

- `helm package ./hermes`
- `helm lint ./hermes --values ./hermes/values.yaml --values ./hermes/values-{env}.yaml`
- `helm install hermes ./hermes --wait --values ./hermes/values.yaml --values ./hermes/values-{env}.yaml`
    - Development: `values-dev.yaml`
    - Production: `values-prod.yaml`

## Architecture

## Tech stack
- .NET 6
- ASP.NET Core
- Docker
- Kubernetes
- Helm Charts
- Redis Stack

## Versioning
A version must follow the [SemVer 2](https://semver.org/spec/v2.0.0.html) standard.

## References
- [.NET Microservices: Architecture for Containerized .NET Applications](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/)
- [.NET Microservices Sample Reference Application](https://github.com/dotnet-architecture/eShopOnContainers)
- [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217)