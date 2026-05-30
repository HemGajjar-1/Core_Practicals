# Practical-20

## Objective

Implement the following concepts in ASP.NET Core Web API:

* Global Exception Handling using Middleware
* Auditing and Application Logging
* Database Logging with File Logging Backup
* Generic Repository Pattern
* Unit Of Work Pattern
* Asynchronous CRUD Operations
* Swagger API Testing
* DTOs and Validation

---

# Project Architecture

The project follows Clean/Layered Architecture.

## Solution Structure

```text
Practical_20
│
├── Practical_20.API
│   ├── Controllers
│   ├── Middleware
│   ├── Models
│   └── Program.cs
│
├── Practical_20.Application
│   ├── DTOs
│   ├── Interfaces
│   └── Services
│
├── Practical_20.Domain
│   ├── Common
│   └── Entities
│
└── Practical_20.Infrastructure
    ├── Data
    ├── Logging
    ├── Repositories
    └── UnitOfWork
```

---

# Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger/OpenAPI
* Repository Pattern
* Unit Of Work Pattern
* Middleware
* Dependency Injection
* Async/Await

---

# Features Implemented

## 1. Global Exception Handling Middleware

A custom middleware was implemented to:

* Catch unhandled exceptions globally
* Return structured JSON error responses
* Log errors automatically

### Files

```text
Practical_20.API/Middleware/ExceptionMiddleware.cs
```

### Benefits

* Centralized exception handling
* Cleaner controllers
* Better maintainability

---

## 2. Auditing

Auditing was implemented using a base entity.

### Audit Fields

* CreatedAt
* CreatedBy
* UpdatedAt
* UpdatedBy

### Files

```text
Practical_20.Domain/Common/BaseEntity.cs
```

Audit values are automatically populated inside:

```text
ApplicationDbContext.SaveChangesAsync()
```

### Benefits

* Automatic tracking of entity changes
* Reduced repetitive code
* Better data monitoring

---

## 3. Generic Repository Pattern

A reusable generic repository was implemented for CRUD operations.

### Interface

```text
IGenericRepository<T>
```

### Implementation

```text
GenericRepository<T>
```

### Features

* GetAllAsync()
* GetByIdAsync()
* AddAsync()
* Update()
* Delete()
* FindAsync()

### Benefits

* Code reusability
* Separation of data access logic
* Cleaner architecture

---

## 4. Unit Of Work Pattern

Unit Of Work was implemented to:

* Centralize transaction handling
* Coordinate repositories
* Commit changes using one DbContext

### Interface

```text
IUnitOfWork
```

### Implementation

```text
UnitOfWork
```

### Benefits

* Transaction consistency
* Better maintainability
* Centralized SaveChangesAsync()

---

## 5. Asynchronous Programming

All database operations were implemented asynchronously using:

* async
* await
* ToListAsync()
* FindAsync()
* SaveChangesAsync()

### Benefits

* Non-blocking operations
* Better scalability
* Improved application performance

---

## 6. Application Logging

Logging was implemented using:

### Database Logging

Errors are stored inside:

```text
ApplicationLogs
```

### File Logging Backup

If database logging fails, logs are automatically stored inside:

```text
Logs/log_yyyyMMdd.txt
```

### Benefits

* Persistent error tracking
* Backup logging mechanism
* Easier debugging and monitoring

---

## 7. Swagger API Testing

Swagger was enabled for testing API endpoints.

### CRUD APIs

* GET /api/employees
* GET /api/employees/{id}
* POST /api/employees
* PUT /api/employees/{id}
* DELETE /api/employees/{id}

### Benefits

* Easy API testing
* Interactive documentation
* Faster debugging

---

## 8. DTOs and Validation

DTOs were implemented to avoid exposing entities directly.

### DTOs Used

* CreateEmployeeDto
* UpdateEmployeeDto
* EmployeeResponseDto

### Validation Attributes

* [Required]
* [MaxLength]
* [Range]

### Benefits

* Better API security
* Clean request/response models
* Automatic validation

---

# Database Tables

## Employees

| Column     | Description         |
| ---------- | ------------------- |
| Id         | Primary Key         |
| Name       | Employee Name       |
| Department | Employee Department |
| Salary     | Employee Salary     |
| CreatedAt  | Creation Date       |
| CreatedBy  | Created By          |
| UpdatedAt  | Updated Date        |
| UpdatedBy  | Updated By          |

---

## ApplicationLogs

| Column     | Description          |
| ---------- | -------------------- |
| Id         | Primary Key          |
| Message    | Error Message        |
| StackTrace | Exception StackTrace |
| Level      | Log Level            |
| CreatedAt  | Log Time             |

---

# Request Flow

```text
Client Request
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
SQL Server
```

---

# Middleware Flow

```text
Request
    ↓
Exception Middleware
    ↓
Controller
    ↓
Service
    ↓
Repository
    ↓
Response
```

---

# Key Concepts Learned

* Clean Architecture
* Repository Pattern
* Unit Of Work Pattern
* Middleware
* Exception Handling
* Auditing
* Logging
* DTOs
* Validation
* Async Programming
* Dependency Injection
* Swagger API Testing

---

# Conclusion

This practical demonstrates the implementation of a professional ASP.NET Core Web API using Clean Architecture principles.

The application includes:

* Generic Repository Pattern
* Unit Of Work Pattern
* Global Exception Handling
* Database and File Logging
* Auditing
* Async CRUD Operations
* DTO-based API Structure
* Validation

The project provides a strong foundation for enterprise-level backend application development using ASP.NET Core and Entity Framework Core.
