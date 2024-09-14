# Customer Management GraphQL API

This project is a basic GraphQL API built with ASP.NET Core, demonstrating the use of various modern .NET technologies and architectural patterns.

## Technologies Used

- ASP.NET Core
- Entity Framework Core (with in-memory database)
- GraphQL (Hot Chocolate)
- FluentValidation
- MediatR
- CQRS architectural pattern (without event sourcing)
- xUnit for testing

## Getting Started

### Prerequisites

- .NET 7.0 SDK or later

### Running the API

To start the API, run the following command from the root directory of the project:

```bash
dotnet run --project src/CustomerManagement.API/CustomerManagement.API.csproj
```

### Running the Tests

To run the tests, run the following command from the root directory of the project:

```bash
dotnet test tests/CustomerManagement.Tests/CustomerManagement.Tests.csproj
```

## Project Structure

- `src/CustomerManagement.API`: Contains the API controllers and GraphQL setup
- `src/CustomerManagement.Core`: Contains domain entities, interfaces, and business logic
- `src/CustomerManagement.Infrastructure`: Contains data access and external service implementations
- `tests/CustomerManagement.Tests`: Contains unit and integration tests

## Usage

### GraphQL Queries

- **Get All Customers**:
  ```query GetAllCustomers {
  customers {
    id
    fullName
    email
  }
}
  ```

- **Get Customer by ID**:
  ```query GetCustomer($id: Int!) {
  customer(id: $id) {
    id
    fullName
    email
  }
}
  ```

### GraphQL Mutations

- **Add Customer**:
  ```mutation CreateCustomer($firstName: String!, $lastName: String!, $email: String!) {
  createCustomer(firstName: $firstName, lastName: $lastName, email: $email) {
    successful
    data {
      id
      fullName
      email
    }
    errors {
      message
      propertyName
    }
  }
}
  ```

## API Documentation

The API is automatically documented using Hot Chocolate. You can access Banana Cake Pop at:

```bash
https://localhost:5143/graphql
```