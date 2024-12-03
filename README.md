# Examify

Examify is a distributed application designed to manage exams, quizzes, and related academic activities. It leverages modern technologies and libraries to provide a scalable and efficient solution for educational institutions.

## Technologies Used

-	**.NET 9**: The application targets .NET 9, utilizing the latest features and improvements of the .NET platform.
-	**C# 13**: The codebase is written in C# version 13, taking advantage of modern language features.
-	**Aspire Host**: Simplifies the hosting and deployment of the application by abstracting Docker configurations.
-	**Entity Framework Core**: Used for interacting with PostgreSQL databases.
-	**gRPC**: Facilitates efficient communication between microservices.
-	**MassTransit**: An abstraction over message brokers like RabbitMQ, simplifying message-based operations.
-	**OpenTelemetry**: Enables observability, logging, tracing, and monitoring.
-	**Redis**: Used for caching to improve application performance.

## Project Structure
The solution is composed of several projects:
-	**Examify.AppHost**: The main entry point of the application, utilizing Aspire Host for setup and deployment.
-	**Examify.Core**: Contains core functionalities, domain models, and shared logic used across the application.
-	**Examify.Infrastructure**: Provides infrastructure services, including database context, configurations, and common utilities.
-	**Examify.Identity**: Manages authentication and authorization services.
-	**Examify.Catalog**: Handles the management of quizzes, exams, and questions.
-	**Examify.Quiz**: Manages quiz-related operations and services.
-	**Examify.Result**: Processes and stores exam results.
-	**Examify.Notification**: Sends notifications to users via email or other channels.
-	**Examify.Gateway**: Acts as an API gateway, directing requests to the appropriate services.
-	**Examify.UploadFile**: Manages file uploads within the application.

## Prerequisites
Before setting up the project, ensure you have the following installed:
-	**.NET SDK 9.0**: [Download and install](https://dotnet.microsoft.com/download/dotnet/9.0)
-	**Docker**: [Download and install](https://www.docker.com/products/docker-desktop) (minimal interaction required due to Aspire Host)
