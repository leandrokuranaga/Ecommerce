
# 📘 Technical Documentation – ECommerce Project

## 🏗️ Architecture Overview

The system follows a **layered architecture** aligned with **Domain-Driven Design (DDD)** principles and uses **CQRS** to separate read and write responsibilities.

### Project Layers:

1. **API Layer (`ECommerce.API`)**
   - Exposes HTTP endpoints using **ASP.NET Core 8**.
   - Integrated with **Swagger** for API documentation.
   - Uses **Keycloak** for authentication and authorization.
   - Includes robust input validation and detailed error responses (not limited to generic 400/404/500).

2. **Application Layer (`ECommerce.Application`)**
   - Contains **Commands**, **Queries**, and **Validators**.
   - Implements the **CQRS pattern** for separation of concerns.
   - Validation handled with **FluentValidation**.

3. **Read Models Layer (`ECommerce.ReadModels`)**
   - Provides optimized read models for queries.
   - Uses caching with both **L1 (in-memory)** and **L2 (distributed, e.g., Redis)** levels for performance.

4. **Domain Layer (`ECommerce.Domain`)**
   - Core business logic with domain entities, aggregates, and interfaces.

5. **Infrastructure Layer**
   - **`ECommerce.Infra.Data`**: Data persistence using **EF Core with PostgreSQL**, with entity mappings and seed data.
   - **`ECommerce.Infra.CrossCutting.Http` / `IoC`**: Cross-cutting services and dependency injection setup.
   - **`ECommerce.Infra.ServiceBus`**: Asynchronous communication with **RabbitMQ**, using publishers and consumers.
   - **`ECommerce.Infra.Utils`**: Utility classes and configurations.

6. **Testing Layer (`ECommerce.Tests`)**
   - Organized into unit and integration test projects.
   - Integration tests use **TestContainers** for isolated environments.
   - Code coverage monitored via **SonarQube**.

## 🔄 Event Sourcing

- Event sourcing implemented using **MongoDB** to persist and replay domain events.
- Enables full traceability and system state reconstruction.

## 🛠️ DevOps and CI/CD

- **CI/CD pipeline** built with **GitHub Actions** using **YAML** workflows.
- Branching strategy: `feature → dev → qa → main → prod`.
- Environment-specific configurations with `appsettings.{Environment}.json`.
- Automates build, tests, Docker image creation, and Kubernetes deployment.
- Deployment strategies include:
  - **Blue/Green Deployment**
  - **Canary Releases**

## 🐳 Infrastructure

- **Docker** for containerizing the application and dependencies.
- **Kubernetes** for orchestration, with namespace separation and scaling.
- **YARP** used as a reverse proxy and gateway.

## 🔐 Authentication and Authorization

- Integrated with **Keycloak** for identity management.
- JWT tokens validated through middleware for secure access.

## 📊 Observability & Monitoring

- **Structured logging** with trace ID propagation.
- **Tracing and profiling** via **OpenTelemetry**.
- **Metrics** exposed for Prometheus consumption.
- **Health checks** available with detailed endpoints and Swagger integration.

## 📦 Tools & Enhancements

- Indexed tables in PostgreSQL for performance.
- Available **Postman collection** for API testing.
- Release management and versioning strategy implemented.
- Environments fully configured for consistent deployments.
