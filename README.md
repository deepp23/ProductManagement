``` markdown
# Product Management API

A RESTful API built with ASP.NET Core 8.0 for managing products and categories with JWT authentication.

## Features

- JWT Authentication and Role-based Authorization
- Product Management (CRUD operations)
- Category Management
- User Registration and Login
- Swagger Documentation
- Entity Framework Core with SQL Server
- CQRS pattern with MediatR
- AutoMapper for object mapping
- FluentResults for better error handling

## Technologies

- .NET 8.0
- ASP.NET Core
- Entity Framework Core
- SQL Server
- MediatR
- AutoMapper
- JWT Authentication
- Swagger/OpenAPI
- BCrypt.NET (for password hashing)

## Project Structure
```
├── Application/ # Application layer (DTOs, Commands, Queries, Handlers) ├── Domain/ # Domain layer (Entities, Interfaces) ├── Infrastructure/ # Infrastructure layer (DbContext, Repositories, Auth) └── API/ # API layer (Controllers, Program.cs)
``` 

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- SQL Server
- An IDE (Visual Studio, Rider, or VS Code)

### Installation

1. Clone the repository
```
bash git clone [your-repo-url]
``` 

2. Update the connection string in `appsettings.json`
```
json { "ConnectionStrings": { "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=True;TrustServerCertificate=True;" } }
``` 

3. Update JWT settings in `appsettings.json`
```
json { "Jwt": { "Key": "your-secret-key", "Issuer": "your-issuer", "Audience": "your-audience" } }
``` 

4. Run the migrations
```
bash dotnet ef database update
``` 

5. Run the application
```
bash dotnet run
``` 

## API Endpoints

### Authentication
- POST `/api/auth/register` - Register a new user
- POST `/api/auth/login` - Login and get JWT token

### Products
- GET `/api/products` - Get all products
- GET `/api/products/{id}` - Get product by ID
- POST `/api/products` - Create a new product
- PUT `/api/products/{id}` - Update a product
- DELETE `/api/products/{id}` - Delete a product

### Categories
- GET `/api/categories` - Get all categories
- GET `/api/categories/{id}` - Get category by ID
- POST `/api/categories` - Create a new category
- PUT `/api/categories/{id}` - Update a category
- DELETE `/api/categories/{id}` - Delete a category

## Authorization

The API uses JWT bearer tokens for authentication. Include the token in the Authorization header:
```
Authorization: Bearer your-token-here
``` 

## Documentation

API documentation is available via Swagger UI at `/swagger` when running in development mode.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
```
