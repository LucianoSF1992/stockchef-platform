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

## 🚀 Roadmap

### 📦 Fundação do Projeto
- [x] Criação do repositório
- [x] Configuração inicial da solução
- [x] Estrutura em Clean Architecture
- [x] Documentação README (EN/PT-BR)
- [x] Configuração da licença
- [x] Configuração do Git Ignore
- [x] Configuração do EditorConfig

### 🏛️ Camada de Domínio
- [x] Abstração BaseEntity
- [x] Entidade Categoria
- [x] Correção dos avisos de nulabilidade
- [x] Entidade Fornecedor
- [x] Enumeração Unidade de Medida
- [x] Entidade Produto
- [x] Enumeração Tipo de Movimentação de Estoque
- [x] Entidade Movimentação de Estoque
- [ ] Objetos de Valor (Value Objects)

### ⚙️ Camada de Aplicação
- [x] DTOs de Categoria
- [x] DTOs de Fornecedor
- [x] DTOs de Produto
- [x] DTOs de Movimentação de Estoque
- [x] Casos de Uso (módulo Categoria iniciado)
- [x] Comandos e Consultas (CQRS)
- [x] Validadores
- [x] Configuração de Injeção de Dependência
- [ ] Pipeline Behaviors do MediatR
- [ ] Mapeamentos com AutoMapper

### 🗄️ Camada de Infraestrutura
- [x] Configuração do Entity Framework Core
- [x] Implementação do DbContext
- [x] Mapeamentos das Entidades
- [x] Implementações dos Repositórios
- [x] Integração com SQL Server
- [x] Migração Inicial
- [ ] Cache Distribuído
- [ ] Serviço de Armazenamento de Arquivos
- [ ] Integração com Mensageria

### 🌐 Camada da API
- [x] Controladores
- [x] Documentação Swagger
- [ ] Tratamento Global de Exceções
- [ ] Versionamento da API
- [ ] Limitação de Requisições (Rate Limiting)
- [ ] Monitoramento e Health Checks

### 📋 Funcionalidades
- [x] Gestão de Produtos
- [x] Gestão de Categorias
- [x] Gestão de Fornecedores
- [x] Movimentações de Estoque
- [ ] Controle de Estoque
- [ ] Dashboard
- [ ] Autenticação e Autorização
- [ ] Relatórios
- [ ] Alertas de Estoque Baixo
- [ ] Histórico de Movimentações
- [ ] Auditoria

### 🖥️ Frontend Web (Angular)
- [ ] Configuração do projeto Angular
- [ ] Estrutura baseada em módulos e funcionalidades
- [ ] Layout responsivo
- [ ] Página de Login
- [ ] Dashboard
- [ ] Cadastro de Produtos
- [ ] Cadastro de Categorias
- [ ] Cadastro de Fornecedores
- [ ] Movimentações de Estoque
- [ ] Relatórios
- [ ] Integração com JWT
- [ ] Guards e Interceptors
- [ ] Gerenciamento de Estado
- [ ] Internacionalização (PT-BR / EN / ES)

### 🧪 Qualidade
- [x] Testes Unitários
- [ ] Testes de Integração
- [ ] Testes de Contrato
- [ ] Testes End-to-End
- [ ] Análise Estática de Código

### 🚀 DevOps
- [ ] Docker
- [ ] Docker Compose
- [ ] Pipeline CI/CD
- [ ] Deploy em Nuvem
- [ ] Monitoramento e Observabilidade

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