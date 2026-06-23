## PCs

This project is a REST Web API for managing computers and their components. It was developed using ASP.NET Core and Entity Framework Core with the Code First approach.
The application follows a layered architecture with a clear separation between presentation layer, business logic and data access.

### Features

- ASP.NET Core Web API
- Entity Framework Core (Code First)
- Database migrations
- Seed data generation
- CRUD operations for computers
- Component management for computers

### API Endpoints

| Method | Endpoint                   | Description                           |
| ------ | -------------------------- | ------------------------------------- |
| GET    | `/api/pcs`                 | Get all computers                     |
| GET    | `/api/pcs/{id}/components` | Get components assigned to a computer |
| POST   | `/api/pcs`                 | Create a new computer                 |
| PUT    | `/api/pcs/{id}`            | Update an existing computer           |
| DELETE | `/api/pcs/{id}`            | Delete a computer                     |

Example Computer Object

```json
{
    "id": 1,
    "name": "Gaming Beast X",
    "weight": 12.5,
    "warranty": 36,
    "createdAt": "2026-05-08T09:00:00",
    "stock": 5
}
```

### Technologies

- ASP.NET Core
- Entity Framework Core
- SQL Server
- C#
