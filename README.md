# Importing Firm Management System

## Overview

This is a web-based application built using ASP.NET Core for the backend and React for the frontend managing an importing firm's business processes. The system allows users to manage import orders, providers, products, product categories, and user information. It provides an easy-to-use interface to streamline the firm's operations.

This project consists of two main components: 

1. **Backend**: An ASP.NET Core API for managing the import firm's operations (orders, providers, products, categories, and users).
2. **Frontend**: A React application that includes a dashboard to display and manage import orders.
![dashboard](dashboard.JPG)


## Features

- **Import Orders**: Create and manage import orders, view order details, and track order statuses.
- **Providers**: Manage providers, their contact information, and associate them with import orders.
- **Products**: Add and manage products, assign them to categories, and link them to providers.
- **Product Categories**: Organize products into categories for easy management and reporting.
- **Users**: Manage user roles, permissions, and authentication for accessing the system.

## API Endpoints

### 1. ImportOrder
- `GET /api/importorder` : Get all import orders
- `GET /api/importorder/{id}` : Get import order by ID
- `POST /api/importorder` : Create a new import order
- `PUT /api/importorder/{id}` : Update an existing import order
- `DELETE /api/importorder/{id}` : Delete an import order

### 2. Provider
- `GET /api/provider` : Get all providers
- `GET /api/provider/{id}` : Get provider by ID
- `POST /api/provider` : Create a new provider
- `PUT /api/provider/{id}` : Update an existing provider
- `DELETE /api/provider/{id}` : Delete a provider

### 3. Product
- `GET /api/product` : Get all products
- `GET /api/product/{id}` : Get product by ID
- `POST /api/product` : Add a new product
- `PUT /api/product/{id}` : Update product details
- `DELETE /api/product/{id}` : Delete a product

### 4. ProductCategory
- `GET /api/productcategory` : Get all product categories
- `GET /api/productcategory/{id}` : Get product category by ID
- `POST /api/productcategory` : Create a new product category
- `PUT /api/productcategory/{id}` : Update an existing product category
- `DELETE /api/productcategory/{id}` : Delete a product category

### 5. User
- `GET /api/user` : Get all users
- `GET /api/user/{id}` : Get user by ID
- `POST /api/user` : Create a new user
- `PUT /api/user/{id}` : Update user details
- `DELETE /api/user/{id}` : Delete a user

## Technologies Used

- **ASP.NET Core** for backend API development
- **Entity Framework Core** for database interactions
- **SQL Server** as the database management system
- **Identity** for user authentication and role management
- **Swagger** for API documentation

## Setup Instructions

1. **Clone the repository**:
```bash
   git clone https://github.com/yourusername/importing-firm-system.git
```

2. **Navigate to the project directory**:

```bash
    Copy code
    cd importing-firm-system
    Set up the database connection in appsettings.json with your SQL Server instance.
```

3. **Run the application**:

```bash
    Copy code
    dotnet run
    Access the application at http://localhost:5000 or https://localhost:5001.
```

