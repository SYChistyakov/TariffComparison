# Tariff Comparison

The Tariff Comparison project is designed to provide a comparison of electricity tariffs based on an input of annual consumption.

The Tariff Comparison solution consists of two applications - a backend written in ASP.NET Web API and a frontend written in Angular / TypeScript. The solution is split into six projects:

1. `TariffComparison.API`: The backend web API.
2. `TariffComparison.API.Tests`: Unit tests for the API.
3. `TariffComparison.Data.Mock`: Mock data access layer.
4. `TariffComparison.Domain`: Contains the domain model and logic.
5. `TariffComparison.Domain.Tests`: Unit tests for the domain.
6. `TariffComparison.Web`: The Angular frontend application.

## Hosting Web Files

In the current project, the Angular application and the backend services are hosted independently, primarily to demonstrate the use of a multi-container setup. This design allows the backend API and frontend application to be containerized separately, offering an opportunity to explore the use of Docker Compose. While hosting the frontend and backend together by serving static files through the ASP.NET backend API service could simplify deployment, it was deemed advantageous for this project to demonstrate a multi-container deployment. 

Please note that this choice was made primarily for showcase purposes, and real-world projects may require a different approach based on specific requirements and constraints.

## HTTP versus HTTPS

The current implementation uses HTTP for simplicity and to avoid the complexity associated with SSL certificates for HTTPS. In a real-world scenario, it's strongly recommended to use HTTPS for secure communication. However, for the sake of simplicity and time efficiency in this showcase project, we have used HTTP. 

Please note that this choice doesn't reflect best practices for production-grade applications, where HTTPS should be implemented to ensure secure data transmission.

## Prerequisites

- .NET 7.0 SDK
- Node.js
- Angular CLI
- Docker (optional)

## How to run the solution

You can use Docker Compose to run the entire solution:

```shell
docker-compose up --build
```

The `--build` option ensures that Docker images for both the API and web application are built before starting the services.

This command will start two services:

- `tariff-comparison-web` accessible on `http://localhost:8080`
- `tariff-comparison-api` accessible on `http://localhost:5000`

The web application is configured to use the `API_URL` environment variable to connect to the backend API.

## API Usage

The API exposes a single endpoint at `POST /api/tariffs/comparison` that accepts an integer representing electricity consumption in kWh/year and returns a list of tariffs with their annual costs.

## Tests

Unit tests for the API service are included in the `TariffComparison.API.Tests` and `TariffComparison.Domain.Tests` projects and can be run using the dotnet test command.

## Future Improvements

- Add a cache layer to improve performance. 
- Add more comprehensive tests, including integration tests for the API and UI tests.
- Improve error handling.
