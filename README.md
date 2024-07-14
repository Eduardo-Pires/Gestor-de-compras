# Controle de Faturas e Produtos

Este é um projeto pessoal desenvolvido utilizando ASP.NET Core e SQL Server para criar uma aplicação web de controle de faturas e produtos com deploy na Azure.

## Funcionalidades

- Gerenciamento completo de faturas e produtos.
- CRUD (Create, Read, Update, Delete) para faturas e produtos.

## Tecnologias Utilizadas

- ASP.NET Core
- SQL Server
- Entity Framework
- HTML
- Javascript
- Bootstrap
- Azure
  
## Como Executar o Projeto

- Online
  - só acessar em [Gestor de Compras](https://gestordecompras.azurewebsites.net)

- LocalHost
  1. Clone o repositório.
  2. Abra o projeto preferencialmente no Visual Studio Code.
  3. Configure a conexão com o banco de dados SQL Server nos arquivo `appsettings.Development.json` e/ou `appsettings.json`, modificando o campo "ConexaoPadrao".
  4. execute os comandos:
```
      dotnet ef migrations add {coloque aqui o nome que desejar para a migration}
      dotnet ef database update
```
 6. Execute o projeto utilizando o comando:

```
     dotnet watch run

```
