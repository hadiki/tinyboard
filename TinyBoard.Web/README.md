````md
# TinyBoard

A tiny Kanban-style board built with **.NET 10 + Blazor Server**.  
Create cards, move them between columns (To Do / Doing / Done), and persist everything in **PostgreSQL**.

## Features
- 3-column board: **To Do**, **Doing**, **Done**
- Create card (title required, notes optional)
- Move card between columns
- Delete card
- Persistence with **EF Core + PostgreSQL**
- Dockerized local stack (**web + database**) with `docker compose`

## Tech Stack
- **.NET 10**
- **Blazor Server**
- **Entity Framework Core**
- **PostgreSQL**
- **Docker / Docker Compose**
- (Optional) **GitHub Actions CI**

---

## Run Locally (Docker) ✅ Recommended

### Prerequisites
- Docker Desktop (macOS/Windows) or Docker Engine (Linux)

### Start the app
From the repository root:

```bash
docker compose up --build
````

Then open:

* [http://localhost:8080](http://localhost:8080)

### Database

PostgreSQL is exposed on:

* Host: `localhost`
* Port: `5433`
* Database: `tinyboard`
* Username: `tinyboard`
* Password: `tinyboard`

Data is persisted in a Docker volume (`tinyboard_pgdata`).

To reset everything (including DB data):

```bash
docker compose down -v
```

---

## Run Locally (without Docker)

### Prerequisites

* .NET 10 SDK
* PostgreSQL running locally

Update `appsettings.Development.json` to your local Postgres credentials, then run:

```bash
dotnet restore
dotnet run
```

Open:

* [http://localhost:xxxx](http://localhost:xxxx) (the port printed in the console)

---

## Migrations (EF Core)

Create a migration:

```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add <MigrationName>
```

Apply migrations:

```bash
dotnet ef database update
```

> When running via Docker Compose, the app is configured to connect to the `db` container automatically using environment variables.

---

## Tests

Run tests from repo root:

```bash
dotnet test
```

---

## Project Structure (simplified)

* `Home.razor` — main board UI
* `Models/` — `CardItem`, `CardStatus`
* `Data/` — `AppDbContext` (+ migrations)
* `Services/` — `CardService` (CRUD)

---

## Backlog (Scrum)

This project is developed with a simple Scrum backlog (Sprint 1: MVP board + persistence, Sprint 2: DevOps + CI).

---

## Future Improvements

* Edit card in a modal
* Drag & drop between columns
* Filtering/search
* Audit log for card changes
* Authentication + roles (admin/user)

---

## License

MIT (or choose another license).
