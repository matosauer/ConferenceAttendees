# Conference Attendees

## Overview

The code is following of Trevoir Williams course on Pluralsight.
Conference Attendees is an educational project designed to support the course "ASP.NET Core - Cloud-Native App Development." This project demonstrates the integration and deployment of a complex application using Docker Compose.

## Architecture

- **API**: Serves as the backend, handling business logic and data access.
- **MVC Client Application**: Frontend application providing user interface.
- **Microsoft SQL Server**: Database server for data storage.
- **Seq Service**: Used for logging and monitoring the application.

## Prerequisites

- Docker

## Setup Instructions

Create an .env file in the root directory of the project with the following content:
```env
SEQ_PASSWORD=YourSeqPassword
MSSQL_SA_PASSWORD=YourSQLPassword
```

Build and Run with Docker Compose

```bash
docker-compose up --build
```
This command will build the images for each service and run the containers.

## Setup Database
The database will be automatically created and seeded with initial data when the application starts. You can verify the database setup by connecting to the SQL Server instance using a SQL client.

## Tools
- NSwaggers is used for API documentation and testing. You can access the Swagger UI at `http://localhost:5000/swagger` after running the application.
- NSwagStudio is used for generating client code and documentation based on the API specifications.
- Serilog is used for logging within the application, providing structured logging capabilities.
- Seq is used for centralized logging and monitoring of the application. You can access the Seq dashboard at `http://localhost:5341` after running the application.
