# 🎮 Game Tournament API

A RESTful ASP.NET Core Web API for managing game tournaments.  
This project was developed as part of a Web Development course assignment.

---

## 📌 Features

The API provides full CRUD functionality for managing tournaments:

- Create tournaments
- Retrieve all tournaments
- Search tournaments by title
- Retrieve a tournament by ID
- Update tournament details
- Delete tournaments

---

## 🏗️ Project Architecture

The project follows a clean-ish layered structure:

Controllers/ → Handles HTTP requests
Services/ → Business logic
Dtos/ → Data transfer objects
Models/ → Entity classes
Data/ → DbContext & database configuration


Key principles used:

- Thin Controllers
- Service-based logic layer
- Dependency Injection
- DTO pattern
- Separation of concerns

---

## 🗄️ Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- Data Annotations Validation

---

## 📡 API Endpoints

### 🏆 Tournaments

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/tournament` | Get all tournaments |
| GET | `/api/tournament?search=keyword` | Search tournaments by title |
| GET | `/api/tournament/{id}` | Get tournament by ID |
| POST | `/api/tournament` | Create a new tournament |
| PUT | `/api/tournament/{id}` | Update an existing tournament |
| DELETE | `/api/tournament/{id}` | Delete a tournament |

---

## 🔁 DTOs Used

The API uses DTOs instead of exposing entities directly:

- **TournamentCreateDTO** → Used for POST requests
- **TournamentUpdateDTO** → Used for PUT requests
- **TournamentResponseDTO** → Used for responses

---

## 🛡️ Validation Rules

Validation is implemented using DataAnnotations:

- Title is required
- Title must be at least 3 characters
- Date cannot be in the past (custom validation attribute)

---

## 🗄️ Database

- EF Core Code-First approach
- SQL Server database
- Migrations used to generate tables
- Async database operations

---

## ▶️ Running the Project

1. Clone the repository:

```bash
git clone <your-repo-url>
Update connection string in appsettings.json

Run migrations:

Update-Database
Start the project:
