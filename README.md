# Examify

Examify is a distributed application designed to manage exams, quizzes, and related academic activities. It leverages modern technologies and libraries to provide a scalable and efficient solution for educational institutions.

## Technologies Used
### Backend

-	**.NET 9**: The application targets .NET 9, utilizing the latest features and improvements of the .NET platform.
-	**C# 13**: The codebase is written in C# version 13, taking advantage of modern language features.
-	**Aspire Host**: Simplifies the hosting and deployment of the application by abstracting Docker configurations.
-	**Entity Framework Core**: Used for interacting with PostgreSQL databases.
-	**gRPC**: Facilitates efficient communication between microservices.
-	**MassTransit**: An abstraction over message brokers like RabbitMQ, simplifying message-based operations.
-	**MediatR**: Implements the mediator pattern for handling requests and notifications.
-	**OpenTelemetry**: Enables observability, logging, tracing, and monitoring.
-	**Redis**: Used for caching to improve application performance.
- **OpenTelemetry**: Collects telemetry data for monitoring and observability.
-	**YARP**: A reverse proxy toolkit for building fast proxy servers in .NET.

### Frontend
- **ReactJS**: A JavaScript library for building user interfaces. It allows developers to create large web applications that can update and render efficiently in response to data changes.
- **React Query**: A library for fetching, caching, and updating asynchronous data in React applications. It simplifies data fetching and state management, making it easier to handle server state in your application.
- **Axios**: A promise-based HTTP client for the browser and Node.js, used for making HTTP requests.

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
-	**Examify.WebClient**: Contains the ReactJS frontend application.

## Prerequisites
Before setting up the project, ensure you have the following installed:
-	**.NET SDK 9.0**: [Download and install](https://dotnet.microsoft.com/download/dotnet/9.0)
-	**Docker**: [Download and install](https://www.docker.com/products/docker-desktop) (minimal interaction required due to Aspire Host)

## Setup Instructions
Follow these steps to set up and run the application:

### Backend setup
**1. Clone the Repository**

```bash
git clone https://github.com/transinh085/Examify.git
cd Examify
```

**2. Build the Solution**

Use the .NET CLI to restore dependencies and build the solution:

```bash
dotnet restore
dotnet build
```

**3. Run the Application**

Start the application by running the Examify.AppHost project. Aspire Host will handle the setup and orchestration of required services:

```bash
dotnet run --project Examify.AppHost
```

This command initializes the application, and Aspire Host automatically configures and manages necessary dependencies such as databases and message brokers.
### Frontend setup
**1. Navigate to the frontend project directory**

```bash
cd Examify.WebClient
```

**2. Install the npm packages**

  ```bash 
  npm install
  ```
  
**3. Start the ReactJS application**

  ```bash
  npm run dev 
  ```

## License
This project is licensed under the MIT License. See the LICENSE file for details.
## Contact
For any questions or feedback, please open an issue in the repository.

_Note: The setup instructions have been simplified to reflect the use of Aspire Host, which manages Docker configurations and service orchestration internally. Manual Docker commands and extensive configurations are no longer necessary._
