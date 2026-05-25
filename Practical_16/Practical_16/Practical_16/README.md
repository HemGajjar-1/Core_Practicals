
# Project Title

A brief description of what this project does and who it's for

# Practical-16: ASP.NET Core Web API Fundamentals

## Aim

To create a new ASP.NET Core Web API project using Visual Studio and understand:

- Default project folder structure
- Environment Configurations
- Request Pipeline
- Middleware
- Built-in Dependency Injection
- Routing
- Built-in Logger (ILogger)
- Visual Studio IntelliSense

---

## Software Requirements

- Visual Studio 2022
- .NET 8 SDK (or installed .NET version)
- Swagger/OpenAPI Support

---

## Project Structure

### Controllers
Contains API controllers that handle HTTP requests.

### Properties
Contains `launchSettings.json` used for application launch profiles and environment configuration.

### appsettings.json
Stores application configuration settings.

### Program.cs
Application entry point where services and middleware are configured.

### bin and obj
Generated build and compilation files.

---

## Environment Configuration

ASP.NET Core supports multiple environments:

- Development
- Staging
- Production

Environment settings are configured in:

```json
{
  "environmentVariables": {
    "ASPNETCORE_ENVIRONMENT": "Development"
  }
}
```
