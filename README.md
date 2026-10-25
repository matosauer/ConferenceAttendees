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

Copy `.env.example` to `.env` in the root directory of the project, then replace the placeholder passwords:
```env
SEQ_PASSWORD=YourSeqPassword
MSSQL_SA_PASSWORD=YourSQLPassword
API_DATABASE_CONNECTION="Server=sql_server,1433;Database=ConferenceAttendeeDb;User Id=sa;Password=${MSSQL_SA_PASSWORD};Encrypt=False;TrustServerCertificate=True;MultipleActiveResultSets=true"
```

The API reads `ConnectionStrings__ConferenceAttendeeDatabaseConnection` from its container environment. Docker Compose supplies that setting from `API_DATABASE_CONNECTION` in the root `.env` file. The connection string uses `MSSQL_SA_PASSWORD` so the database password only needs to be set once.

Modify host file to add the following line:
```
127.0.0.1       conferenceattendees.com
127.0.0.1       api.conferenceattendees.com
```

Build and Run with Docker Compose

```bash
docker-compose up --build
```
This command will build the images for each service and run the containers.

## Setup Database
The database will be automatically created and seeded with initial data when the application starts. You can verify the database setup by connecting to the SQL Server instance using a SQL client.

## Certificates
Install WSL (Windows Subsystem for Linux) if you are using Windows. You can do this by running the following command in PowerShell as Administrator:
wsl --install

### 1. Generate a self-signed certificate for the API and UI services using OpenSSL. Run the following commands in your terminal:
sudo openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout api-cert.key -out api-cert.crt -config api-cert.conf
sudo openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout ymvc-cert.key -out ymvc-cert.crt -config ymvc-cert.conf

### 2. Generate PFX certificates
sudo openssl pkcs12 -export -out api-cert.pfx -inkey api-cert.key -in api-cert.crt
sudo openssl pkcs12 -export -out ymvc-cert.pfx -inkey ymvc-cert.key -in ymvc-cert.crt

### 3. Move the generated PFX certificates to the appropriate directory in your project (e.g., `certs` folder).
### 4. Install the certificates on your local machine. On Windows, you can double-click the PFX file and follow the prompts to install it in the "Trusted Root Certification Authorities" store.

## Tools
- NSwaggers is used for API documentation and testing. You can access the Swagger UI at `http://localhost:5000/swagger` after running the application.
- NSwagStudio is used for generating client code and documentation based on the API specifications. https://github.com/RicoSuter/NSwag
- Serilog is used for logging within the application, providing structured logging capabilities.
- Seq is used for centralized logging and monitoring of the application. You can access the Seq dashboard at `http://localhost:5341` after running the application.
- Postman is used for testing API endpoints and verifying the functionality of the application.