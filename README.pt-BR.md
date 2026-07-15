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

### Fundação do Projeto
- [x] Criação do repositório
- [x] Configuração inicial da solução
- [x] Estrutura da Clean Architecture
- [x] Documentação do README (EN/PT-BR)
- [x] Configuração da licença
- [x] Configuração do Git Ignore
- [x] Configuração do EditorConfig

### Camada de Domínio
- [x] Abstração da BaseEntity
- [x] Entidade Category
- [x] Correção dos avisos de referências anuláveis
- [x] Entidade Supplier
- [x] Enum UnitOfMeasure
- [x] Entidade Product
- [x] Enum StockMovementType
- [x] Entidade StockMovement
- [ ] Objetos de Valor (Value Objects)

### Camada de Aplicação
- [x] DTOs de Categoria
- [X] DTOs de Fornecedor
- [X] DTOs de Produto
- [X] DTOs de Movimentação de Estoque
- [ ] Casos de Uso
- [X] Commands e Queries (módulo de categorias iniciado)
- [ ] Validadores
- [ ] Configuração da Injeção de Dependência

### Camada de Infraestrutura
- [x] Configuração do Entity Framework Core
- [x] Implementação do DbContext
- [x] Mapeamentos das entidades
- [ ] Implementação dos repositórios
- [x] Integração com SQL Server
- [x] Primeira Migration

### Camada da API
- [X] Controllers
- [x] Documentação Swagger
- [ ] Tratamento global de exceções
- [ ] Versionamento da API

### Funcionalidades
- [X] Gestão de produtos
- [X] Gestão de categorias
- [X] Gestão de fornecedores
- [X] Movimentações de estoque
- [ ] Controle de inventário
- [ ] Dashboard
- [ ] Autenticação e autorização
- [ ] Relatórios

### Qualidade
- [ ] Testes unitários
- [ ] Testes de integração

### DevOps
- [ ] Docker
- [ ] CI/CD
- [ ] Publicação em nuvem

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