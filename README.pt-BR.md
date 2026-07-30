# StockChef Platform

[🇺🇸 English](README.md) | 🇧🇷 Português

---

# Sobre o Projeto

O **StockChef Platform** é uma aplicação web full stack para gerenciamento de estoque de restaurantes.

O projeto está sendo desenvolvido para demonstrar práticas modernas de desenvolvimento de software corporativo utilizando:

- ASP.NET Core 9
- Angular
- Clean Architecture
- Domain-Driven Design (DDD)
- CQRS com MediatR
- Entity Framework Core
- SQL Server

A aplicação permitirá o gerenciamento de produtos, categorias, fornecedores e movimentações de estoque, seguindo princípios de escalabilidade, manutenibilidade, código limpo e boas práticas de arquitetura.

---

# Objetivos do Projeto

- Desenvolver uma aplicação corporativa baseada em um cenário real.
- Aplicar os princípios da Clean Architecture.
- Praticar conceitos de Domain-Driven Design (DDD).
- Implementar CQRS utilizando MediatR.
- Desenvolver APIs REST com ASP.NET Core.
- Construir um frontend moderno utilizando Angular.
- Implementar autenticação e autorização.
- Desenvolver testes automatizados.
- Configurar pipelines de CI/CD.
- Publicar a aplicação em ambiente de nuvem.

---

# Funcionalidades

- Gestão de Produtos
- Gestão de Categorias
- Gestão de Fornecedores
- Movimentações de Estoque
- Controle de Inventário
- Dashboard
- Relatórios
- Autenticação e Autorização

---

# Tecnologias Utilizadas

## Backend

- C#
- ASP.NET Core 9
- Entity Framework Core
- SQL Server
- MediatR
- REST API
- JWT Authentication (planejado)

## Frontend

- Angular 22
- Angular Material
- TypeScript
- RxJS

## Arquitetura

- Clean Architecture
- Domain-Driven Design (DDD)
- Princípios SOLID
- Repository Pattern
- Injeção de Dependência
- CQRS (MediatR)

---

# Estrutura do Projeto

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

# Status do Projeto

🚧 Em desenvolvimento

**Foco atual:**

- Desenvolvimento da API
- Modelagem de Domínio
- Implementação de CQRS
- Repository Pattern

O frontend em Angular será iniciado após a conclusão das principais funcionalidades da API.

---

# 🚀 Roadmap

## 📦 Fundação do Projeto

- [x] Criação do repositório
- [x] Configuração inicial da solução
- [x] Estrutura em Clean Architecture
- [x] README (EN/PT-BR)
- [x] Licença MIT
- [x] Configuração do .gitignore
- [x] Configuração do .editorconfig

---

## 🏛 Camada de Domínio

- [x] BaseEntity
- [x] Entidade Categoria
- [x] Entidade Fornecedor
- [x] Entidade Produto
- [x] Entidade Movimentação de Estoque
- [x] Enum UnitOfMeasure
- [x] Enum StockMovementType
- [ ] Value Objects

---

## ⚙️ Camada de Aplicação

### Categorias

- [x] DTOs
- [x] Commands
- [x] Queries
- [x] Handlers

### Produtos

- [x] DTOs
- [x] Commands
- [x] Queries
- [x] Handlers

### Fornecedores

- [x] DTOs
- [x] Create Command
- [x] Create Handler
- [ ] Queries
- [ ] Update Command
- [ ] Delete Command

### Movimentações de Estoque

- [x] DTOs
- [ ] Commands
- [ ] Queries
- [ ] Handlers

### Componentes Compartilhados

- [x] Configuração de Injeção de Dependência
- [ ] FluentValidation
- [ ] Pipeline Behaviors do MediatR
- [ ] AutoMapper

---

## 🗄 Camada de Infraestrutura

- [x] Entity Framework Core
- [x] DbContext
- [x] SQL Server
- [x] Migração Inicial

### Repositórios

- [x] CategoryRepository
- [x] ProductRepository
- [x] SupplierRepository
- [ ] StockMovementRepository

### Futuras Implementações

- [ ] Cache Distribuído
- [ ] Serviço de Armazenamento de Arquivos
- [ ] Integração com Mensageria

---

## 🌐 Camada da API

- [x] Swagger
- [x] CategoryController
- [ ] ProductController
- [ ] SupplierController
- [ ] StockMovementController
- [ ] Middleware Global de Exceções
- [ ] Versionamento da API
- [ ] Rate Limiting
- [ ] Health Checks

---

## 📋 Módulos de Negócio

- [x] Gestão de Categorias
- [x] Gestão de Produtos
- [ ] Gestão de Fornecedores
- [ ] Movimentações de Estoque
- [ ] Controle de Estoque
- [ ] Dashboard
- [ ] Relatórios
- [ ] Autenticação e Autorização
- [ ] Alertas de Estoque Baixo
- [ ] Auditoria

---

## 🖥 Frontend Web (Angular)

- [ ] Configuração do Projeto Angular
- [ ] Angular Material
- [ ] Layout Responsivo
- [ ] Tela de Login
- [ ] Dashboard
- [ ] Gestão de Produtos
- [ ] Gestão de Categorias
- [ ] Gestão de Fornecedores
- [ ] Movimentações de Estoque
- [ ] Relatórios
- [ ] Integração com JWT
- [ ] Guards
- [ ] Interceptors
- [ ] Gerenciamento de Estado
- [ ] Internacionalização (PT-BR / EN / ES)

---

## 🧪 Qualidade

- [ ] Testes Unitários
- [ ] Testes de Integração
- [ ] Testes de Contrato
- [ ] Testes End-to-End
- [ ] Análise Estática de Código

---

## 🚀 DevOps

- [ ] Docker
- [ ] Docker Compose
- [ ] GitHub Actions
- [ ] Pipeline CI/CD
- [ ] Deploy em Nuvem
- [ ] Monitoramento
- [ ] Observabilidade

---

# Deploy

Após a conclusão da versão **1.0**, a aplicação estará disponível em:

https://stockchefplatform.lucianoferreiradev.com

---

# Autor

**Luciano Silva Ferreira**

🌐 **Portfólio**  
https://www.lucianoferreiradev.com

💼 **LinkedIn**  
https://www.linkedin.com/in/lucianoferreira92/

💻 **GitHub**  
https://github.com/LucianoSF1992

---

# Licença

Este projeto está licenciado sob a licença **MIT**.

---

⭐ Se este projeto foi útil para você, considere deixar uma estrela no repositório.