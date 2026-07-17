## StockChef Platform

![Status](https://img.shields.io/badge/status-under%20development-yellow)
![.NET](https://img.shields.io/badge/.NET-9.0-512BD4)
![Angular](https://img.shields.io/badge/Angular-latest-DD0031)
![License](https://img.shields.io/badge/license-MIT-green)

🇺🇸 English | [🇧🇷 Português](README.pt-BR.md)

## About

StockChef Platform is a full-stack web application for restaurant inventory management.

The project aims to provide an efficient way to manage products, categories, suppliers, stock movements, and operational information while demonstrating modern software engineering practices using ASP.NET Core, Angular and Clean Architecture.

This project is being developed as part of my software engineering portfolio, following professional development practices and focusing on clean code, scalability, maintainability, and testability.

---

## Project Goals

- Build a real-world enterprise application
- Apply Clean Architecture principles
- Practice Domain-Driven Design concepts
- Develop RESTful APIs with ASP.NET Core
- Build a modern Angular frontend
- Implement authentication and authorization
- Write automated tests
- Configure CI/CD pipelines
- Deploy the application to the cloud

---

## Features

- Product management
- Category management
- Supplier management
- Stock movements
- Inventory control
- Dashboard
- Authentication & Authorization
- Reports

## Tech Stack

### Backend

- C#
- ASP.NET Core
- Entity Framework Core
- SQL Server
- REST API
- JWT Authentication

### Frontend

- Angular
- Angular Material
- TypeScript
- RxJS

### Architecture

- Clean Architecture
- SOLID Principles
- Dependency Injection
- Repository Pattern
- Unit of Work
- CQRS (future implementation)

---

## Project Status

🚧 Under development

---

## 🚀 Roadmap

### 📦 Project Foundation
- [x] Repository creation
- [x] Initial solution setup
- [x] Clean Architecture structure
- [x] README documentation (EN/PT-BR)
- [x] License configuration
- [x] Git ignore configuration
- [x] EditorConfig configuration

### 🏛️ Domain Layer
- [x] BaseEntity abstraction
- [x] Category entity
- [x] Nullable warnings fix
- [x] Supplier entity
- [x] UnitOfMeasure enum
- [x] Product entity
- [x] StockMovementType enum
- [x] StockMovement entity
- [ ] Value Objects

### ⚙️ Application Layer
- [x] Category DTOs
- [x] Supplier DTOs
- [x] Product DTOs
- [x] Stock Movement DTOs
- [x] Use Cases (Category module started)
- [x] Commands and Queries (CQRS)
- [x] Validators
- [x] Dependency Injection configuration
- [ ] MediatR Pipeline Behaviors
- [ ] AutoMapper mappings

### 🗄️ Infrastructure Layer
- [x] Entity Framework Core configuration
- [x] DbContext implementation
- [x] Entity mappings
- [x] Repository implementations
- [x] SQL Server integration
- [x] Initial migration
- [ ] Distributed Cache
- [ ] File Storage Service
- [ ] Messaging integration

### 🌐 API Layer
- [x] Controllers
- [x] Swagger documentation
- [ ] Global exception handling
- [ ] API versioning
- [ ] Rate limiting
- [ ] Monitoring and Health Checks

### 📋 Features
- [x] Product management
- [x] Category management
- [x] Supplier management
- [x] Inventory movements
- [ ] Inventory control
- [ ] Dashboard
- [ ] Authentication & Authorization
- [ ] Reports
- [ ] Low stock alerts
- [ ] Movement history
- [ ] Audit trail

### 🖥️ Web Frontend (Angular)
- [ ] Angular project setup
- [ ] Feature-based architecture
- [ ] Responsive layout
- [ ] Login page
- [ ] Dashboard
- [ ] Product management screens
- [ ] Category management screens
- [ ] Supplier management screens
- [ ] Inventory movement screens
- [ ] Reports
- [ ] JWT integration
- [ ] Guards and Interceptors
- [ ] State management
- [ ] Internationalization (PT-BR / EN / ES)

### 🧪 Quality
- [x] Unit Tests
- [ ] Integration Tests
- [ ] Contract Tests
- [ ] End-to-End Tests
- [ ] Static Code Analysis

### 🚀 DevOps
- [ ] Docker
- [ ] Docker Compose
- [ ] CI/CD Pipeline
- [ ] Cloud Deployment
- [ ] Monitoring and Observability

---

## Deployment

After the project completion, the application will be available at the following address:

https://stockchefplatform.lucianoferreiradev.com

---

## Author

Developed by **Luciano Silva Ferreira**

- 🌐 Portfolio: <https://www.lucianoferreiradev.com/>
- 💼 LinkedIn: <https://www.linkedin.com/in/lucianoferreira92/>
- 💻 GitHub: https://github.com/LucianoSF1992
