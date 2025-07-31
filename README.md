# 📚 Biblioteca API - Gerenciamento de Livros

Este projeto é uma API desenvolvida em **.NET Core** com o objetivo de gerenciar livros em uma biblioteca, permitindo operações como cadastro, listagem de livros e exclusão.

## 🚀 Tecnologias Utilizadas

- **.NET Core** – Backend robusto e escalável para construção da API.
- **Entity Framework Core** – ORM utilizado para mapeamento e acesso aos dados no banco de forma eficiente.
- **FluentValidation** – Utilizado para validação das *Input Models*, garantindo integridade e consistência dos dados recebidos.
- **Arquitetura DDD (Domain-Driven Design)** – Organização do código baseada em domínios de negócio, promovendo melhor manutenção e separação de responsabilidades.

## 📦 Funcionalidades

- ✅ Cadastrar novos livros  
- ✅ Remover livros do catálogo  
- ✅ Listar todos os livros disponíveis  
- ✅ Obter detalhes de um livro por ID  

## 📂 Estrutura do Projeto (DDD)

O projeto segue os princípios da arquitetura **Domain-Driven Design**, separando as responsabilidades em camadas:

- **Domain** – Entidades e regras de negócio.
- **Application** – Casos de uso e lógica de aplicação.
- **Infrastructure** – Acesso a dados e dependências externas.
- **API** – Camada de apresentação e endpoints HTTP.

## 🛠 Como executar

- É necessário ter o [.NET 8.0 instalado](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
- É necessário o uso do SQL Server para o banco de dados
- Recomendo o uso do Visual Studio para rodar a aplicação

1. Clone o repositório:
   ```bash
   git clone https://github.com/joseEdu456/api-livros.git
   ```
 
2. No arquivo appsettings.json, na seção de conexão com o banco altere a conection string ApiLivroConnection para a seguinte:
  ```bash
  "Data source=SeuLocalHost; Initial Catalog=ApiLivros; Integrated Security=true; TrustServerCertificate=True"
  ```
3. Após isso abra o NugetPackage Console e rode os seguinte comando para criar e aplicar as migrations no banco de dados
  ```bash
  Add-Migration PrimeiraMigracao -Context LivroDbContext -o Persistence/Migrations
  Update-Database -Context LivroDbContext
  ```
