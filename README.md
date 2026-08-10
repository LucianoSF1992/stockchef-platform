# StockChef Platform

![Status](https://img.shields.io/badge/status-under%20development-yellow)
![.NET](https://img.shields.io/badge/.NET-9.0-512BD4)
![Angular](https://img.shields.io/badge/Angular-22-DD0031)
![License](https://img.shields.io/badge/license-MIT-green)

🇺🇸 English | [🇧🇷 Português](README.pt-BR.md)

---

# About

StockChef Platform is a full-stack web application for restaurant inventory management.

The project is being developed to demonstrate enterprise software development practices using:

- ASP.NET Core 9
- Angular
- Clean Architecture
- Domain-Driven Design (DDD)
- CQRS with MediatR
- Entity Framework Core
- SQL Server

The application allows restaurants to manage products, suppliers, categories and inventory while following modern software engineering principles focused on scalability, maintainability and clean code.

---

# Project Goals

- Build a real-world enterprise application
- Apply Clean Architecture principles
- Practice Domain-Driven Design
- Implement CQRS using MediatR
- Develop RESTful APIs
- Build a modern Angular frontend
- Implement Authentication & Authorization
- Write automated tests
- Configure CI/CD pipelines
- Deploy to the cloud

---

# Features

- Product Management
- Category Management
- Supplier Management
- Stock Movements
- Inventory Control
- Dashboard
- Reports
- Authentication & Authorization

---

# Tech Stack

## Backend

- C#
- ASP.NET Core 9
- Entity Framework Core
- SQL Server
- MediatR
- REST API
- JWT Authentication (planned)

## Frontend

- Angular 22
- Angular Material
- TypeScript
- RxJS

## Architecture

- Clean Architecture
- Domain-Driven Design (DDD)
- SOLID Principles
- Repository Pattern
- Dependency Injection
- CQRS (MediatR)

---

# Project Status

🚧 Under Development

Current focus:

- Backend API
- Domain Modeling
- CQRS Implementation
- Repository Pattern

Frontend development will start after the backend reaches feature completeness.

---

# 🚀 Roadmap

## 📦 Project Foundation

- [x] Repository creation
- [x] Solution structure
- [x] Clean Architecture
- [x] README (EN/PT-BR)
- [x] MIT License
- [x] .gitignore
- [x] .editorconfig

---

## 🏛 Domain Layer

- [x] BaseEntity
- [x] Category
- [x] Supplier
- [x] Product
- [x] StockMovement
- [x] UnitOfMeasure
- [x] StockMovementType
- [x] Stock movement business rules
- [ ] Value Objects

---

## ⚙️ Application Layer

### Categories

- [x] DTOs
- [x] Commands
- [x] Queries
- [x] Handlers
- [x] Validators

### Products

- [x] DTOs
- [x] Commands
- [x] Queries
- [x] Handlers

### Suppliers

- [x] DTOs
- [x] Commands
- [x] Queries
- [x] Handlers

### Stock Movements

- [x] DTOs
- [x] Commands
- [x] Queries
- [x] Handlers

### Cross-Cutting

- [x] Dependency Injection
- [ ] FluentValidation
- [ ] MediatR Pipeline Behaviors
- [ ] AutoMapper

---

## 🗄 Infrastructure Layer

- [x] Entity Framework Core
- [x] DbContext
- [x] Entity mappings
- [x] SQL Server
- [x] Initial Migration

### Repositories

- [x] CategoryRepository
- [x] ProductRepository
- [x] SupplierRepository
- [x] StockMovementRepository

### Future

- [ ] Distributed Cache
- [ ] File Storage
- [ ] Messaging

---

## 🌐 API Layer

- [x] Swagger
- [x] Category Controller
- [x] Product Controller
- [x] Supplier Controller
- [x] StockMovement Controller
- [ ] Global Exception Middleware
- [ ] API Versioning
- [ ] Rate Limiting
- [ ] Health Checks

---

## 📋 Business Modules

- [x] Category Management
- [x] Product Management
- [x] Supplier Management
- [x] Inventory Movements
- [x] Inventory Control
- [ ] Dashboard
- [ ] Reports
- [ ] Authentication & Authorization
- [ ] Low Stock Alerts
- [ ] Audit Trail

---

## 🖥 Angular Frontend

- [ ] Angular Project
- [ ] Angular Material
- [ ] Responsive Layout
- [ ] Login
- [ ] Dashboard
- [ ] Products
- [ ] Categories
- [ ] Suppliers
- [ ] Inventory
- [ ] Reports
- [ ] JWT Integration
- [ ] Guards
- [ ] Interceptors
- [ ] State Management
- [ ] Internationalization (PT-BR / EN / ES)

---

## 🧪 Testing

- [x] Unit Tests
- [ ] Integration Tests
- [ ] Contract Tests
- [ ] End-to-End Tests
- [ ] Static Code Analysis

---

## 🚀 DevOps

- [ ] Docker
- [ ] Docker Compose
- [ ] GitHub Actions
- [ ] CI/CD Pipeline
- [ ] Cloud Deployment
- [ ] Monitoring
- [ ] Observability

---

# Deployment

After the project reaches version **1.0**, it will be available at:

https://stockchefplatform.lucianoferreiradev.com

---

# Author

**Luciano Silva Ferreira**

🌐 Portfolio  
https://www.lucianoferreiradev.com/

💼 LinkedIn  
https://www.linkedin.com/in/lucianoferreira92/

💻 GitHub  
https://github.com/LucianoSF1992

---

⭐ If you enjoyed this project, consider giving it a star.