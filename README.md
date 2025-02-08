# Projeto: API de Reservas e Faturamento

Este projeto é uma API desenvolvida para gerenciar um sistema de reservas de hotéis, incluindo funcionalidades de controle de **suítes**, **reservas** e **faturamento**. A API foi construída com **ASP.NET Core** e está integrada a um banco de dados **SQL Server**.

## Funcionalidades
- **Suítes**: Gerenciamento de suítes disponíveis para reserva.
- **Reservas**: Cadastro, consulta e cancelamento de reservas.
- **Faturamento**: Geração de faturas com base nas reservas realizadas.
- **Autenticação**: Endpoint para login de usuários e geração de tokens JWT.

## Requisitos
- **.NET 8.0**
- **SQL Server** (pode ser local ou hospedado).
- **Postman** ou **Swagger** para interagir com a API.

## Como rodar o projeto

### 1. Baixando o Projeto
1. Clone o repositório para a sua máquina local:
    ```bash
    git clone https://github.com/zinhocoder/ProjectRoot.git
    ```

### 2. Configuração do Banco de Dados
- O projeto utiliza **SQL Server** para persistência de dados. Já esta configurado para o acesso localmente.
- 
- Rode as migrations para criar as tabelas no banco de dados:
    ```bash
    dotnet ef database update
    ```

### 3. Executando o Projeto
1. No diretório do projeto, execute o comando:
    ```bash
    dotnet run
    ```

2. A API será iniciada em `http://localhost:5000 ou na porta em que o console retornar.`.

### 4. Testando a API com o Postman

**Endpoints principais:**
- **POST /api/auth/login**: Autenticação de usuário.
    - Corpo (JSON):
      ```json
      {
          "username": "usuario",
          "password": "senha"
      }
      ```
- **GET /api/suites**: Recupera a lista de suítes disponíveis.
- **POST /api/reservas**: Cria uma nova reserva.
    - Corpo (JSON):
      ```json
      {
          "suiteId": 1,
          "userId": 1,
          "dataInicio": "2025-02-10T14:00:00",
          "dataFim": "2025-02-15T12:00:00"
      }
      ```
- **GET /api/faturamento**: Gera o faturamento com base nas reservas.

### 5. Interagindo com o Swagger

- Quando o projeto estiver rodando, você pode acessar o Swagger para testar os endpoints diretamente em:  
  `http://localhost:5000/swagger`

  O Swagger fornecerá uma interface gráfica para você testar as rotas de forma intuitiva, sem a necessidade de ferramentas como o Postman.

## Estrutura de Pastas

/ProjectRoot │ ├── /Controllers # Contém os controladores da API ├── /Models # Contém os modelos de dados ├── /Services # Lógica de negócios da API (ex: TokenService) ├── /Data # Contexto de dados e configurações de acesso ao banco ├── /Migrations # Migrações do banco de dados ├── /wwwroot # Arquivos estáticos (se necessário) ├── /appsettings.json # Configurações da aplicação, como a string de conexão └── /Program.cs # Arquivo de inicialização do projeto



## Tecnologias Utilizadas

- **ASP.NET Core**: Framework para construção da API.
- **SQL Server**: Banco de dados relacional.
- **JWT (JSON Web Token)**: Para autenticação e segurança.
- **Swagger**: Para documentação da API e testes interativos.

Se você tiver alguma dúvida ou encontrar problemas, sinta-se à vontade para abrir uma issue no GitHub.

### Explicações:
1. **Como rodar a API**: O `README.md` orienta sobre como rodar a API, configurar o banco de dados e usar as migrations.
2. **Postman**: Você pode usar o Postman para testar a API, e o `README.md` inclui exemplos de requisições.
3. **Swagger**: Fornece uma interface gráfica para testar e visualizar a documentação dos endpoints.
4. **Estrutura de pastas**: Ajuda outros desenvolvedores a entenderem rapidamente como o projeto está organizado.

Esse arquivo deve cobrir a maioria das necessidades de quem for rodar e usar sua API. Se precisar de mais detalhes ou ajustes, fique à vontade para pedir! 😊
