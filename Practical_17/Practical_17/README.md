# Practical-17: Student Management System using ASP.NET Core Web API

## Objective

Develop a Student Management System using ASP.NET Core Web API following Clean Architecture principles. Implement Entity Framework Core Code First approach, ASP.NET Core Identity for Authentication and Authorization, Repository Pattern, Unit of Work Pattern, DTOs, FluentValidation, Soft Delete functionality, and Dependency Injection.

---

## Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- Cookie Authentication
- FluentValidation
- Dependency Injection
- Repository Pattern
- Unit Of Work Pattern
- Swagger / OpenAPI

---

## Solution Structure

```text
Practical_17
│
├── Practical_17.Domain
│   ├── Common
│   │   └── BaseEntity.cs
│   │
│   └── Entities
│       ├── Student.cs
│       └── ApplicationUser.cs
│
├── Practical_17.Application
│   ├── DTOs
│   │   ├── Auth
│   │   │   ├── LoginDto.cs
│   │   │   └── RegisterDto.cs
│   │   │
│   │   └── Student
│   │       ├── StudentDto.cs
│   │       ├── CreateStudentDto.cs
│   │       └── UpdateStudentDto.cs
│   │
│   ├── Interfaces
│   │   ├── Repositories
│   │   ├── Services
│   │   └── UnitOfWork
│   │
│   ├── Services
│   └── Validators
│
├── Practical_17.Infrastructure
│   ├── Data
│   │   └── ApplicationDbContext.cs
│   │
│   ├── Repositories
│   │   ├── GenericRepository.cs
│   │   └── StudentRepository.cs
│   │
│   ├── Seeders
│   │   └── IdentitySeeder.cs
│   │
│   └── UnitOfWork
│       └── UnitOfWork.cs
│
└── Practical_17.API
    ├── Controllers
    │   ├── AuthController.cs
    │   └── StudentController.cs
    │
    ├── Program.cs
    └── appsettings.json
```

---

## Features

### Student Management

- Create Student
- Get All Students
- Get Student By Id
- Update Student
- Soft Delete Student

### Authentication

- User Registration
- User Login
- User Logout

### Authorization

- Admin Role
- User Role
- Role Based Access Control

### Validation

- FluentValidation
- DTO Validation
- Automatic Request Validation

### Database

- Entity Framework Core Code First
- SQL Server
- EF Core Migrations
- Soft Delete Support

---

## Architecture

### Domain Layer

Contains entities and core business models.

### Application Layer

Contains DTOs, Interfaces, Validators and Business Services.

### Infrastructure Layer

Contains DbContext, Repositories, Unit Of Work and Identity Seeders.

### API Layer

Contains Controllers, Dependency Injection configuration and API endpoints.

---

## Entity Relationship

### ApplicationUser

Custom Identity user:

- FirstName
- LastName
- Email
- PhoneNumber

Inherited from `IdentityUser`.

### Roles

- Admin
- User

Managed by ASP.NET Core Identity.

### Student

- Id
- FirstName
- LastName
- Email
- Age
- Course
- CreatedAt
- UpdatedAt
- IsDeleted

---

## Authentication Flow

```text
Register User
      ↓
Create Identity User
      ↓
Assign User Role
      ↓
Store User in Database
```

```text
Login
      ↓
Validate Credentials
      ↓
Create Authentication Cookie
      ↓
Authorized Access
```

---

## Authorization Rules

| Endpoint | User | Admin |
|----------|------|--------|
| View Students | Yes | Yes |
| Create Student | No | Yes |
| Update Student | No | Yes |
| Delete Student | No | Yes |

---

## Soft Delete

Instead of deleting records permanently:

```csharp
entity.IsDeleted = true;
```

Global Query Filter:

```csharp
builder.Entity<Student>()
       .HasQueryFilter(x => !x.IsDeleted);
```

Deleted records remain in the database but are excluded from normal queries.

---

## Repository Pattern

### Generic Repository Operations

```csharp
Task<IEnumerable<T>> GetAllAsync();
Task<T?> GetByIdAsync(int id);
Task AddAsync(T entity);
void Update(T entity);
void Delete(T entity);
```

### Benefits

- Reusable CRUD logic
- Separation of concerns
- Easier maintenance
- Better testability

---

## Unit Of Work

Coordinates repositories and commits changes using:

```csharp
Task<int> SaveChangesAsync();
```

### Benefits

- Single transaction boundary
- Consistent database updates
- Centralized save operation

---

## Dependency Injection Lifetimes

### Transient

```csharp
services.AddTransient<T>();
```

Creates a new instance every time it is requested.

### Scoped

```csharp
services.AddScoped<T>();
```

Creates one instance per HTTP request.

Used for:

- DbContext
- Repositories
- Services
- UnitOfWork

### Singleton

```csharp
services.AddSingleton<T>();
```

Creates one instance for the entire application lifetime.

---

## Identity Seeding

Automatically creates:

### Roles

- Admin
- User

### Default Admin Account

Email:

```text
admin@admin.com
```

Password:

```text
Admin@123
```

---

## API Endpoints

### Authentication

```http
POST /api/Auth/register
POST /api/Auth/login
POST /api/Auth/logout
```

### Students

```http
GET    /api/Student
GET    /api/Student/{id}
POST   /api/Student
PUT    /api/Student/{id}
DELETE /api/Student/{id}
```

---

## Database Tables

Generated using EF Core Migrations:

- Students
- AspNetUsers
- AspNetRoles
- AspNetUserRoles
- AspNetUserClaims
- AspNetRoleClaims
- AspNetUserLogins
- AspNetUserTokens

---

## Migration Commands

### Create Migration

```powershell
Add-Migration InitialCreate
```

### Apply Migration

```powershell
Update-Database
```

---

## Learning Outcomes

- Clean Architecture
- ASP.NET Core Identity
- Cookie Authentication
- Authorization using Roles
- Entity Framework Core Code First
- Repository Pattern
- Generic Repository Pattern
- Unit Of Work Pattern
- DTO Pattern
- FluentValidation
- Soft Delete
- Dependency Injection
- SQL Server Integration
- Swagger API Testing

---

## Conclusion

This project demonstrates a secure and scalable Student Management System built using ASP.NET Core Web API and Clean Architecture. It integrates Entity Framework Core, ASP.NET Core Identity, FluentValidation, Repository Pattern, Unit Of Work Pattern and Dependency Injection to create a maintainable and extensible enterprise-style application.