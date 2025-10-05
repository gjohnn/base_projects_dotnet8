# Base Project .NET 8 API

A **production-ready starter backend project** built with .NET 8, featuring complete user authentication, JWT security, and comprehensive API documentation. Perfect foundation for building modern web applications and microservices.

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet)](https://dotnet.microsoft.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-17-4169E1?style=flat&logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![Docker](https://img.shields.io/badge/Docker-Compose-2496ED?style=flat&logo=docker&logoColor=white)](https://www.docker.com/)
[![Dev Containers](https://img.shields.io/badge/Dev_Containers-Ready-23F4C1?style=flat&logo=visualstudiocode)](https://code.visualstudio.com/docs/devcontainers/containers)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

## 🚀 Features

- **🔐 Authentication & Authorization**: Complete JWT-based auth system with registration, login, and password reset
- **👤 User Management**: Full CRUD operations for user entities with secure password hashing
- **🛡️ Security**: BCrypt password hashing, JWT token validation, secure API endpoints
- **📚 API Documentation**: Swagger/OpenAPI integration for interactive API documentation
- **🐘 Database**: PostgreSQL integration with Entity Framework Core migrations
- **🐳 Docker Ready**: Complete Docker Compose setup for development and production
- **📦 Dev Containers**: Pre-configured VS Code development environment with all dependencies
- **🏗️ Clean Architecture**: Well-organized controllers, services, and models structure
- **⚡ Performance**: Optimized for .NET 8 with async/await patterns

## 🛠️ Tech Stack

| Technology | Version | Purpose |
|------------|---------|---------|
| .NET | 8.0 | Web API Framework |
| Entity Framework Core | 9.0 | ORM & Database Migrations |
| PostgreSQL | 17 | Primary Database |
| JWT Bearer | 8.0 | Authentication & Authorization |
| BCrypt.Net | 4.0 | Password Hashing |
| Swagger/OpenAPI | 6.6 | API Documentation |
| Docker | Latest | Containerization |

## 📋 Prerequisites

Before you begin, ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download) (8.0 or later)
- [PostgreSQL 17](https://www.postgresql.org/download/) (or use Docker)
- [Docker & Docker Compose](https://docs.docker.com/get-docker/) (recommended)
- [Entity Framework Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet):

```

## 🚀 Quick Start

### Option 1: Dev Containers (Recommended for VS Code)

The easiest way to get started with a consistent development environment is using **Visual Studio Code Dev Containers**:

**Prerequisites:**
- [Visual Studio Code](https://code.visualstudio.com/)
- [Dev Containers Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)

**Setup:**
1. Clone the repository:
   ```bash
   git clone <your-repo-url>
   cd base_project_dotNet8
   ```

2. Open in VS Code:
   ```bash
   code .
   ```

3. When prompted, click **"Reopen in Container"** or:
   - Press `F1` → Type `Dev Containers: Reopen in Container`
   - Or click the green button in the bottom-left corner

**What you get:**
- ✅ **Pre-configured environment** with .NET 8 SDK, EF Tools, and all dependencies
- ✅ **PostgreSQL database** automatically set up and running
- ✅ **Port forwarding** for API (5000/5001) and database (5432)
- ✅ **VS Code extensions** for C# development pre-installed
- ✅ **SSH server** for external terminal access
- ✅ **Consistent environment** across different machines

The API will be available at:
- **HTTP**: http://localhost:5000
- **HTTPS**: https://localhost:5001
- **Swagger UI**: http://localhost:5000/swagger

### Option 2: Docker Compose

Alternative setup using Docker Compose directly:

```bash
# Clone the repository
git clone <your-repo-url>
cd base_project_dotNet8

# Start the application with Docker Compose
docker-compose up -d

# The API will be available at http://localhost:5022
# PostgreSQL will be available at localhost:5432
```

### Option 3: Local Development

1. **Clone the repository**
   ```bash
   git clone <your-repo-url>
   cd base_project_dotNet8
   ```

2. **Set up PostgreSQL**
   ```bash
   # Option A: Using Docker
   docker run --name postgres-dev -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=base_project -p 5432:5432 -d postgres:17
   
   # Option B: Install PostgreSQL locally and create database
   createdb base_project
   ```

3. **Configure connection string**
   
   Update `appsettings.json` if needed:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=base_project;Username=postgres;Password=postgres"
     }
   }
   ```

4. **Install dependencies and run migrations**
   ```bash
   # Restore packages
   dotnet restore
   
   # Apply database migrations
   dotnet ef database update
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

The API will be available at:
- **HTTP**: http://localhost:5022
- **Swagger UI**: http://localhost:5022/swagger

## 📁 Project Structure

```
├── Controllers/           # API Controllers
│   ├── AuthController.cs     # Authentication endpoints
│   ├── BaseController.cs     # Base controller with common functionality
│   └── TestController.cs     # Test/demo endpoints
├── Models/               # Data Models & DbContext
│   ├── AppDbContext.cs      # Entity Framework DbContext
│   ├── BaseEntity.cs        # Base entity with common properties
│   └── User.cs              # User entity model
├── Services/             # Business Logic Layer
│   ├── AuthService.cs       # Authentication business logic
│   ├── BaseService.cs       # Generic CRUD service
│   └── UserService.cs       # User-specific business logic
├── Migrations/           # Entity Framework Migrations
├── Properties/           # Launch settings
├── appsettings.json      # Application configuration
├── docker-compose.yml    # Docker Compose configuration
├── Dockerfile           # Docker container definition
└── Program.cs           # Application entry point
```

## 🔌 API Endpoints

### Authentication

| Method | Endpoint | Description | Authentication |
|--------|----------|-------------|----------------|
| `POST` | `/api/auth/register` | Register new user | ❌ |
| `POST` | `/api/auth/login` | User login | ❌ |
| `POST` | `/api/auth/reset-password` | Reset user password | ❌ |

### Users

| Method | Endpoint | Description | Authentication |
|--------|----------|-------------|----------------|
| `GET` | `/api/users` | Get all users | ✅ JWT |
| `GET` | `/api/users/{id}` | Get user by ID | ✅ JWT |
| `PUT` | `/api/users/{id}` | Update user | ✅ JWT |
| `DELETE` | `/api/users/{id}` | Delete user | ✅ JWT |

### Example Requests

**Register a new user:**
```bash
curl -X POST "http://localhost:5022/api/auth/register" \
  -H "Content-Type: application/json" \
  -d '{
    "email": "user@example.com",
    "password": "SecurePassword123!"
  }'
```

**Login:**
```bash
curl -X POST "http://localhost:5022/api/auth/login" \
  -H "Content-Type: application/json" \
  -d '{
    "email": "user@example.com",
    "password": "SecurePassword123!"
  }'
```

**Access protected endpoint:**
```bash
curl -X GET "http://localhost:5022/api/users" \
  -H "Authorization: Bearer YOUR_JWT_TOKEN"
```

## ⚙️ Configuration

### Environment Variables

The application supports the following configuration options:

| Variable | Description | Default |
|----------|-------------|---------|
| `ConnectionStrings__DefaultConnection` | PostgreSQL connection string | `Host=db;Port=5432;Database=base_project;Username=postgres;Password=postgres` |
| `Jwt__Key` | JWT signing key | `clave-super-secreta-para-jwt` |
| `Jwt__Issuer` | JWT issuer | `FortiFinanzasApi` |
| `Jwt__Audience` | JWT audience | `FortiFinanzasUsers` |

### JWT Configuration

The JWT configuration in `appsettings.json`:

```json
{
  "Jwt": {
    "Key": "your-super-secret-jwt-key-min-32-chars",
    "Issuer": "YourApiName",
    "Audience": "YourApiUsers"
  }
}
```

**⚠️ Security Note**: Change the JWT key in production and use environment variables for sensitive configuration.

## 🔧 Development

### Dev Containers Features

When using the dev container, you get additional development features:

```bash
# Entity Framework tools are pre-installed
dotnet ef --version

# SSH server for external access
# Set password for SSH access (first time only)
sudo passwd vscode


```

**Available ports in dev container:**
- **5000**: HTTP API endpoint
- **5001**: HTTPS API endpoint (with self-signed certificate)
- **5432**: PostgreSQL database
- **SSH**: Configurable port for external terminal access

**Pre-installed extensions:**
- C# Dev Kit
- .NET Core Extension Pack
- PostgreSQL extension
- Docker extension

### Database Migrations

```bash
# Create a new migration
dotnet ef migrations add YourMigrationName

# Apply migrations to database
dotnet ef database update

# Remove last migration (if not applied)
dotnet ef migrations remove
```

### Running Tests

```bash
# Run all tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"
```

### Code Analysis

```bash
# Format code
dotnet format

# Static analysis (if configured)
dotnet analyze
```

## 🐳 Docker

### Build and Run

```bash
# Build the Docker image
docker build -t base-project-api .

# Run with Docker Compose
docker-compose up -d

# View logs
docker-compose logs -f api

# Stop services
docker-compose down
```

### Production Deployment

For production deployment, consider:

1. **Security**: Update JWT keys and database credentials
2. **Environment**: Use production-appropriate `appsettings.Production.json`
3. **Monitoring**: Add logging and monitoring solutions
4. **Scaling**: Consider load balancing and horizontal scaling


## 🆘 Support

- **Documentation**: Visit the [Swagger UI](http://localhost:5022/swagger) when running locally
- **Issues**: Report bugs and request features via [GitHub Issues](https://github.com/your-repo/issues)
- **Discussions**: Join discussions in [GitHub Discussions](https://github.com/your-repo/discussions)

## 🙏 Acknowledgments

- [.NET Team](https://github.com/dotnet) for the framework
- [Entity Framework Core](https://github.com/dotnet/efcore) for data access
- [PostgreSQL](https://www.postgresql.org/) for the robust database
- [Swagger](https://swagger.io/) for API documentation

