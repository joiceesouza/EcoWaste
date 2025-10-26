# 🌱 EcoWaste - Gestão de Resíduos e Reciclagem

Este projeto faz parte da disciplina **Navegando pelo Mundo DevOps** e tem como objetivo aplicar práticas completas de **CI/CD, containerização e orquestração** utilizando o projeto **EcoWaste**, uma aplicação RESTful desenvolvida em **.NET 8** com foco em **ESG (Sustentabilidade e Gestão de Resíduos)**.

---

## 🚀 Objetivos do Projeto

- Implementar um **pipeline funcional de CI/CD** com GitHub Actions.  
- **Containerizar** a aplicação com Docker.  
- **Orquestrar** os serviços com Docker Compose (API + Banco de Dados).  
- Entregar um projeto completo, documentado e pronto para ambientes *staging* e *production*.

---

## 🏗️ Estrutura do Projeto

````
EcoWaste/
├── .github/
│ └── workflows/
│ └── ci-cd.yml
├── EcoWaste.Api/
├── EcoWaste.Business/
├── EcoWaste.Core/
├── EcoWaste.DataAccess/
├── EcoWaste.Tests/
├── Dockerfile
├── docker-compose.yml
├── .dockerignore
└── README.md
````

---

## 🐳 Containerização com Docker

A aplicação foi containerizada utilizando **build multi-stage**, garantindo uma imagem final otimizada.

⚙️ Como Executar Localmente com Docker

1️⃣ Construir a imagem

`docker build -t ecowaste-api .`

2️⃣ Subir os containers (API + Banco de Dados)

`docker-compose up -d`

3️⃣ Acessar a aplicação

Swagger: http://localhost:8080/swagger

Banco de Dados (SQL Server): localhost:1433

```bash
Usuário: sa

Senha: YourStrong@Password123
````

4️⃣ Parar os containers

`docker-compose down`

🔄 Pipeline CI/CD

A automação foi implementada via GitHub Actions, garantindo integração e entrega contínuas.

🧠 Etapas do Pipeline

| Etapa                           | Descrição                                                |
| ------------------------------- | -------------------------------------------------------- |
| **Checkout**                    | Clona o código do repositório.                           |
| **Setup .NET**                  | Instala o SDK do .NET 8 para build/testes.               |
| **Restore & Build**             | Restaura dependências e compila o projeto.               |
| **Test**                        | Executa os testes automatizados.                         |
| **Publish**                     | Gera os arquivos de publicação.                          |
| **Docker Build**                | Constrói a imagem Docker da API.                         |
| **Deploy Staging & Production** | Simula a entrega automatizada para diferentes ambientes. |


🧰 Tecnologias Utilizadas

.NET 8.0 / ASP.NET Core

C#

SQL Server 2022

Docker & Docker Compose

GitHub Actions (CI/CD)

Swagger / OpenAPI

xUnit (Testes Automatizados)


👥 Autoria

Projeto: EcoWaste - Gestão de Resíduos e Reciclagem

Autora: Joice Souza

Instituição: FIAP

Fase: Navegando pelo Mundo DevOps

Ano: 2025
