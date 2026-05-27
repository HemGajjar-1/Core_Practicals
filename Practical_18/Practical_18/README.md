# Practical-18: Student Management System using ASP.NET Core MVC + Web API

## Objective

Develop a Student Management System using:

* ASP.NET Core MVC
* ASP.NET Core Web API
* Entity Framework Core
* Repository Pattern
* Generic Repository Pattern
* Unit Of Work Pattern
* Service Layer
* AutoMapper
* ViewModels
* SQL Server

The application performs complete CRUD operations on Student data through both:

* MVC Razor Views
* REST API Endpoints

---

# Project Architecture

The project follows Clean Architecture with separation of concerns.

```text
Practical_18.API
Practical_18.Application
Practical_18.Domain
Practical_18.Infrastructure
```

---

# Project Structure

## 1. Practical_18.API

Handles:

* Controllers
* Razor Views
* API Endpoints
* Dependency Injection
* Application Startup

Contains:

```text
Controllers
Views
Program.cs
appsettings.json
```

---

## 2. Practical_18.Application

Handles:

* Interfaces
* Services
* ViewModels
* AutoMapper Profiles

Contains:

```text
Interfaces
Services
Mappings
ViewModels
```

---

## 3. Practical_18.Domain

Handles:

* Core Entities

Contains:

```text
Entities
```

---

## 4. Practical_18.Infrastructure

Handles:

* Database Context
* Repository Pattern
* Generic Repository
* Unit Of Work
* EF Core Operations

Contains:

```text
Data
Repositories
UnitOfWork
Migrations
```

---

# Technologies Used

* ASP.NET Core MVC
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* AutoMapper
* Bootstrap
* Razor Views
* Dependency Injection

---

# Features

## MVC CRUD Operations

* View Students
* Create Student
* Edit Student
* Student Details
* Delete Student

---

## API CRUD Operations

### GET All Students

```http
GET /api/StudentsApi
```

### GET Student By Id

```http
GET /api/StudentsApi/{id}
```

### Create Student

```http
POST /api/StudentsApi
```

### Update Student

```http
PUT /api/StudentsApi/{id}
```

### Delete Student

```http
DELETE /api/StudentsApi/{id}
```

---

# Database Configuration

Connection string is configured inside:

```text
appsettings.json
```

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=Practical18Db;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

# Entity Framework Core Migration Commands

## Add Migration

```powershell
Add-Migration InitialCreate
```

## Update Database

```powershell
Update-Database
```

---

# Student Entity

```csharp
public class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int Age { get; set; }
}
```

---

# Repository Pattern

The Repository Pattern abstracts database operations.

Example:

```text
Controller
    ↓
Service
    ↓
Repository
    ↓
DbContext
    ↓
Database
```

Benefits:

* Cleaner code
* Better maintainability
* Easier testing
* Separation of concerns

---

# Generic Repository

A Generic Repository provides reusable CRUD operations for all entities.

Common methods:

```csharp
GetAllAsync()
GetByIdAsync()
AddAsync()
Update()
Delete()
```

---

# Unit Of Work Pattern

Unit Of Work manages all repositories under one transaction.

Instead of calling:

```csharp
SaveChangesAsync()
```

multiple times, all changes are committed together.

Benefits:

* Centralized transaction management
* Better consistency
* Cleaner architecture

---

# Service Layer

The Service Layer contains business logic.

Flow:

```text
Controller
    ↓
Service Layer
    ↓
Repository Layer
    ↓
Database
```

---

# AutoMapper

AutoMapper is used to map:

```text
Entity ↔ ViewModel
```

Example:

```csharp
CreateMap<Student, StudentViewModel>().ReverseMap();
```

---

# ViewModels

ViewModels are used instead of exposing entities directly to Views or APIs.

Benefits:

* Better security
* Better validation
* Cleaner architecture

---

# Validation

Validation is implemented using Data Annotations.

Example:

```csharp
[Required]
[StringLength(50)]
public string FirstName { get; set; }
```

---

# Concepts Covered

## Model Binding

Automatically binds request data to C# objects.

Example:

```csharp
public IActionResult Create(StudentViewModel model)
```

---

## HTTP Status Codes

Used in API responses:

* 200 OK
* 201 Created
* 204 No Content
* 400 Bad Request
* 404 Not Found

---

## Input / Output Formatters

ASP.NET Core automatically converts:

* JSON → C# Object
* C# Object → JSON

---

## Content Negotiation

The client specifies the response format using HTTP headers.

Example:

```http
Accept: application/json
```

---

# Dependency Injection

Services are registered in:

```csharp
Program.cs
```

Example:

```csharp
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStudentService, StudentService>();
```

---

# How To Run The Project

## Step 1

Set:

```text
Practical_18.API
```

as Startup Project.

---

## Step 2

Run:

```text
Ctrl + F5
```

---

## Step 3

Open MVC Application:

```text
https://localhost:xxxx/Students
```

---

## Step 4

Open Swagger API:

```text
https://localhost:xxxx/swagger
```

---

# Application Flow

```text
Browser / Swagger
        ↓
Controller
        ↓
Service Layer
        ↓
Unit Of Work
        ↓
Repository
        ↓
DbContext
        ↓
SQL Server Database
```

---

# Conclusion

This project demonstrates:

* ASP.NET Core MVC
* ASP.NET Core Web API
* Entity Framework Core
* Repository Pattern
* Generic Repository
* Unit Of Work
* Service Layer
* AutoMapper
* ViewModels
* Razor CRUD Views
* API CRUD Endpoints
* SQL Server Integration
* Dependency Injection
* Model Binding
* HTTP Status Codes
* Input/Output Formatters
* Content Negotiation
