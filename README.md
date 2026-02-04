# 🚗 Sistema de Estacionamento

Aplicação web para **gestão de um estacionamento**, com funcionalidades de **controle de entrada e saída de veículos**, **cálculo de cobrança/faturamento**, **controle de vagas** e apoio a **relatórios**.

> Status: Em desenvolvimento

---

## Sumário

- [Visão geral](#visão-geral)
- [Stack e tecnologias](#stack-e-tecnologias)
- [Arquitetura e organização do projeto](#arquitetura-e-organização-do-projeto)
- [Configuração e execução](#configuração-e-execução)
- [O que foi aprendido](#o-que-foi-aprendido)

---

## Visão geral

O **Sistema de Estacionamento** foi desenvolvido para simular/atender rotinas comuns de um estacionamento:

- Registrar **entrada** de veículos (com dados como tipo, dia etc.)
- Exibir **veículos estacionados** e os **últimos registros**
- Registrar **saída** e acionar o cálculo de valores e registro de pagamento
- Manter informações de **vagas** (total, ocupadas e disponíveis)
- Suporta geração de **relatórios**

A aplicação segue o padrão **ASP.NET Core MVC** (Controllers + Views Razor) com separação em camadas de **Service** e **DAO**.

---

## Stack e tecnologias

### Backend
- **.NET 6** (`net6.0`)
- **ASP.NET Core MVC**

### Persistência / ORM
- **Entity Framework Core 7**
- Provider: **SQL Server**

### Frontend
- **Razor Views** (`.cshtml`)
- **HTML/CSS/JavaScript/JQuery**

### Bibliotecas (NuGet) principais
- `Microsoft.EntityFrameworkCore` (ORM)
- `Microsoft.EntityFrameworkCore.SqlServer` (provider SQL Server)
- `Microsoft.EntityFrameworkCore.Tools` (migrations/tools)
- `Microsoft.EntityFrameworkCore.Proxies` (proxies/lazy loading, se habilitado no DbContext)
- `iTextSharp.LGPLv2.Core` (geração/manipulação de **PDF** para relatórios)

---

## Arquitetura e organização do projeto

A estrutura do repositório está organizada por responsabilidades:

- `Controllers/`  
  Camada web (endpoints MVC). Recebe requisições, chama serviços e retorna Views/Partials.

- `Views/`  
  Camada de UI com Razor. Contém páginas e partial views.

- `Models/`  
  Entidades (mapeadas pelo EF Core) e classes auxiliares.

- `Models/DTO/`  
  DTOs usados para trafegar dados entre camadas/telas.

- `Service/`  
  Regras de negócio (casos de uso). Ex.: `IEstacionamentoService`, `IFaturamentoService`, etc.

- `DAO/`  
  Acesso a dados (operações no banco). Os Services dependem das interfaces DAO.

- `Data/`  
  Contexto do EF Core (`DbContext`) e configurações de mapeamento.

- `Migrations/`  
  Migrações do EF Core (versionamento do schema e seeds).

### Padrão de camadas (fluxo típico)

`Controller` → `Service (Interface)` → `DAO (Interface)` → `DbContext (EF Core)` → `SQL Server`

### Injeção de dependência (DI)

As dependências são registradas no `Program.cs` usando `AddScoped`

---

## Banco de dados

O sistema utiliza **SQL Server** via **Entity Framework Core**.

A string de conexão fica em `appsettings.json` altere para sua instancia local e rode :
- `Update-Database` 
ou
- `dotnet ef database update`

> As tabelas são criadas/atualizadas via **Migrations** do EF Core.

---

## Configuração e execução

### Pré-requisitos
- **.NET SDK 6**
- **SQL Server** 

### Configurar conexão com o banco
Edite `appsettings.json` caso queira apontar para outro SQL Server.

### Criar/atualizar banco (migrations)
Via Package Manager Console (Visual Studio) ou CLI:

- `Update-Database`
ou
- `dotnet ef database update`

### Executar
- Visual Studio: `F5`
- CLI: `dotnet run`

---

## O que foi aprendido

Este projeto exercita e consolida conhecimentos em:

- **ASP.NET Core MVC**
  - Controllers, Actions, rotas, Views Razor e Partial Views
- **Injeção de dependência**
  - Uso de interfaces para registrar serviços
- **Entity Framework Core**
  - Modelos com DataAnnotations (`[Table]`, `[Key]`)
  - Criação de schema com **Migrations**
  - Integração com **SQL Server**
- **Arquitetura em camadas**
  - Separação de responsabilidades: Web → Negócio → Dados
- **Relatórios**
  - Base para geração de PDF com `iTextSharp` (relatórios de faturamento)

---


---
