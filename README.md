# TodoList API

A RESTful Todo List API built with **ASP.NET Core (.NET 10)**, **Entity Framework Core**, **Azure SQL**, and **JWT Authentication**.

---

## 🛠 Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core 10 |
| ORM | Entity Framework Core (Azure SQL) |
| Auth | JWT Bearer Tokens |
| Database | Azure SQL / LocalDB |
| Docs | OpenAPI (Scalar) |

---

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Azure SQL database **or** SQL Server LocalDB

### 1. Clone the repository

```bash
git clone <repo-url>
cd TodoList
```

### 2. Configure settings

Update `TodoList/appsettings.json` (or use `appsettings.Development.json` / user secrets) with your values:

```json
{
  "Jwt": {
    "Key": "YourSuperSecretKey_AtLeast32CharsLong",
    "Issuer": "YourIssuer",
    "Audience": "YourAudience"
  },
  "ConnectionStrings": {
    "AzureSqlConnection": "your-connection-string-here"
  }
}
```

> ⚠️ Never commit real secrets to source control. Use environment variables or [.NET User Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) in development.

### 3. Apply database migrations

```bash
cd TodoList
dotnet ef database update
```

### 4. Run the API

```bash
dotnet run --project TodoList
```

The API will be available at:
- HTTP: `http://localhost:5050`
- HTTPS: `https://localhost:7167`

OpenAPI docs (development only): `http://localhost:5050/openapi/v1.json`

---

## 📁 Project Structure

```
TodoList/
├── Controllers/
│   ├── AuthController.cs       # Register & Login
│   └── TaskController.cs       # CRUD + toggle for tasks
├── DTOs/
│   ├── AuthResponseDto.cs
│   ├── CreateTaskDto.cs
│   ├── LoginDto.cs
│   ├── RefreshTokenRequestDto.cs
│   ├── RegisterDto.cs
│   └── UpdateTaskDto.cs
├── Middleware/
│   └── LoggingMiddleware.cs    # Request/response logging
├── Model/
│   ├── Task.cs
│   └── User.cs
├── Repositories/
│   ├── IAuthRepository.cs / AuthRepository.cs
│   └── ITaskRepository.cs / TaskRepository.cs
├── Services/
│   ├── IAuthService.cs / AuthService.cs
│   └── ITaskService.cs / TaskService.cs
├── AppDbContext.cs
└── Program.cs
```

---

## 🔐 Authentication

The API uses **JWT Bearer** authentication. Protected endpoints require an `Authorization` header:

```
Authorization: Bearer <your_access_token>
```

### Obtain a token

**POST** `/api/auth/register` or **POST** `/api/auth/login` — both return an `accessToken` in the response body.

---

## 📡 API Endpoints

### Auth

| Method | Endpoint | Auth | Description |
|--------|----------|------|-------------|
| POST | `/api/auth/register` | ❌ | Register a new user |
| POST | `/api/auth/login` | ❌ | Login and receive JWT |

### Tasks

All task endpoints require a valid JWT token (`Authorization: Bearer <token>`).

| Method | Endpoint | Auth | Description |
|--------|----------|------|-------------|
| GET | `/api/task` | ✅ | Get all tasks |
| GET | `/api/task/{id}` | ✅ | Get task by ID |
| GET | `/api/task/user/{userId}` | ✅ | Get all tasks for a user |
| POST | `/api/task` | ✅ | Create a new task |
| PUT | `/api/task/{id}` | ✅ | Update a task |
| PATCH | `/api/task/{id}` | ✅ | Toggle task completion |
| DELETE | `/api/task/{id}` | ✅ | Delete a task |

---

## 📦 Request & Response Examples

### Register

**POST** `/api/auth/register`

```json
{
  "name": "John Doe",
  "email": "john@example.com",
  "password": "secret123"
}
```

**Response `200 OK`:**
```json
{
  "userId": 1,
  "name": "John Doe",
  "email": "john@example.com",
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "dateCreated": "2026-04-27T10:00:00Z",
  "dateModified": null
}
```

---

### Login

**POST** `/api/auth/login`

```json
{
  "email": "john@example.com",
  "password": "secret123"
}
```

**Response `200 OK`:** *(same shape as Register)*

---

### Create Task

**POST** `/api/task`

```json
{
  "name": "Buy groceries",
  "description": "Milk, eggs, bread, and butter",
  "isDone": false,
  "userId": 1
}
```

**Response `201 Created`:**
```json
{
  "id": 1,
  "name": "Buy groceries",
  "description": "Milk, eggs, bread, and butter",
  "isDone": false,
  "userId": 1,
  "dateCreated": "2026-04-27T10:05:00Z",
  "dateModified": "0001-01-01T00:00:00Z"
}
```

---

### Update Task

**PUT** `/api/task/{id}`

```json
{
  "name": "Buy groceries updated",
  "description": "Milk, eggs, bread, butter, and coffee",
  "isDone": false
}
```

---

### Toggle Completion

**PATCH** `/api/task/{id}` — No body required. Flips `isDone` between `true` and `false`.

---

## 🗂 Postman Collection

A ready-to-import Postman collection is available at:

```
TodoList.postman_collection.json
```

It includes:
- Pre-configured environment variables (`{{baseUrl}}`, `{{token}}`)
- A **login test script** that automatically saves the JWT to `{{token}}`
- All endpoints with example request bodies

### Quick import

1. Open Postman → **Import** → select `TodoList.postman_collection.json`
2. Set the `baseUrl` variable to `http://localhost:5050` (or your deployed URL)
3. Run **Register** or **Login** — the token is saved automatically
4. All other requests use `{{token}}` automatically

---

## 🧪 Running with HTTP file

A `.http` file is included for quick testing in JetBrains Rider or VS Code REST Client:

```
TodoList/TodoList.http
```

---

## 📝 License

MIT

