# StockChef Platform

[🇺🇸 English](README.md) | 🇧🇷 Português

## Sobre o projeto

O StockChef Platform é uma aplicação web full stack para gerenciamento de estoque de restaurantes.

O projeto tem como objetivo oferecer uma forma eficiente de controlar produtos, categorias, fornecedores, movimentações de estoque e informações operacionais, utilizando tecnologias modernas e boas práticas de engenharia de software.

Este projeto está sendo desenvolvido como parte do meu portfólio profissional, seguindo práticas utilizadas em projetos corporativos e com foco em código limpo, escalabilidade, manutenibilidade e testabilidade.

---

## Objetivos do Projeto

- Desenvolver uma aplicação corporativa baseada em um cenário real.
- Aplicar os princípios da Clean Architecture.
- Praticar conceitos de Domain-Driven Design (DDD).
- Desenvolver APIs REST utilizando ASP.NET Core.
- Construir um frontend moderno utilizando Angular.
- Implementar autenticação e autorização.
- Desenvolver testes automatizados.
- Configurar pipelines de CI/CD.
- Publicar a aplicação em ambiente de nuvem.

---

## Funcionalidades

- Gestão de produtos
- Gestão de categorias
- Gestão de fornecedores
- Movimentações de estoque
- Controle de inventário
- Dashboard operacional
- Autenticação e autorização
- Relatórios gerenciais

---

## Tecnologias Utilizadas

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

### Arquitetura

- Clean Architecture
- Princípios SOLID
- Injeção de Dependência
- Repository Pattern
- Unit of Work
- CQRS (implementação futura)

---

## Estrutura do Projeto

```text
src/
├── StockChef.Api
├── StockChef.Application
├── StockChef.Domain
└── StockChef.Infrastructure

tests/
└── StockChef.UnitTests
```

---

## Status do Projeto

🚧 Em desenvolvimento

---

## Roadmap

### Project Foundation
- [x] Repository creation
- [x] Initial solution setup
- [x] Clean Architecture structure
- [x] README documentation (EN/PT-BR)
- [x] License configuration
- [x] Git ignore configuration
- [x] EditorConfig configuration

### Domain Layer
- [x] BaseEntity abstraction
- [x] Category entity
- [x] Nullable warnings fix
- [ ] Supplier entity
- [ ] Product entity
- [ ] StockMovement entity
- [ ] Domain enums
- [ ] Value Objects

### Application Layer
- [ ] DTOs
- [ ] Use Cases
- [ ] Commands and Queries
- [ ] Validators
- [ ] Dependency Injection configuration

### Infrastructure Layer
- [ ] Entity Framework Core configuration
- [ ] DbContext implementation
- [ ] Entity mappings
- [ ] Repository implementations
- [ ] SQL Server integration
- [ ] Initial migration

### API Layer
- [ ] Controllers
- [ ] Swagger documentation
- [ ] Global exception handling
- [ ] API versioning

### Features
- [ ] Product management
- [ ] Category management
- [ ] Supplier management
- [ ] Inventory movements
- [ ] Inventory control
- [ ] Dashboard
- [ ] Authentication & Authorization
- [ ] Reports

### Quality
- [ ] Unit Tests
- [ ] Integration Tests

### DevOps
- [ ] Docker
- [ ] CI/CD
- [ ] Cloud Deployment

---

## Deploy

Após a conclusão do projeto, a aplicação será publicada no seguinte endereço:

https://stockchefplatform.lucianoferreiradev.com

---

## Autor

Desenvolvido por **Luciano Silva Ferreira**

- 🌐 Portfólio: https://www.lucianoferreiradev.com
- 💼 LinkedIn: https://www.linkedin.com/in/lucianoferreira92/
- 💻 GitHub: https://github.com/LucianoSF1992

---

## Licença

Este projeto está licenciado sob a licença MIT.