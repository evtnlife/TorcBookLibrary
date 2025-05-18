# 📚 TorcBookLibrary

Personal book management system. This project is structured with a **backend** built using .NET 9 + EF Core.

---

## 🧱 Project Structure

```

TorcBookLibrary/
├── backend/
│   ├── TorcBookLibrary.Api/        # Main API project (startup)
│   ├── TorcBookLibrary.Domain/     # Domain entities and interfaces
│   ├── TorcBookLibrary.Infra/      # Data access, Migrations, DbContext
│   └── TorcBookLibrary.Services/   # Business logic

```

---

## 🚀 Running the Backend

1. Navigate to the `backend` folder:

```bash
cd backend
```

2. Run the project:

```bash
dotnet run --project TorcBookLibrary.Api
```

The API will be available by default at `http://localhost:5000` (or as defined in `launchSettings.json`).

---

## 🔧 Database Configuration (EF Core)

This project uses **Entity Framework Core** with a **Code-First** approach.

### 📌 Create Initial Migration

```bash
dotnet ef migrations add InitialCreate -p TorcBookLibrary.Infra -s TorcBookLibrary.Api
```

### 🔄 Update the Database

```bash
dotnet ef database update -p TorcBookLibrary.Infra -s TorcBookLibrary.Api
```

### 📦 Prerequisites

Make sure the required packages and tools are installed:

```bash
dotnet tool install --global dotnet-ef
dotnet add TorcBookLibrary.Infra package Microsoft.EntityFrameworkCore.Design
```

---

## 📫 Basic API Endpoints

| Method | Route              | Description              |
| ------ | ------------------ | ------------------------ |
| GET    | `/api/book`        | Returns all books        |
| GET    | `/api/book/{id}`   | Returns a book by ID     |
| POST   | `/api/book/search` | Searches books by filter |

---

## 📁 Key Files

- `.gitignore`: Ignores `bin/`, `obj/`, `.dll`, `.user`, etc.
- `appsettings.json`: App configuration.
- `Dockerfile`: (Optional) Containerization setup.

---

## 🧪 Tests

(To be implemented)

---

## 💡 Future Improvements

- JWT Authentication
- Query caching (Redis)
- Pagination and sorting
- Swagger with OpenAPI 6 support

---

## 📄 License

This project was developed for technical demonstration purposes. All rights reserved by the author.

```

```
