# ˚୨୧⋆｡˚ ⋆ Projeto API filmes! ⋆ ˚｡⋆୨୧˚



## 😋 Descrição do Projeto
A **API Filmes** é um projeto desenvolvido em **C#** utilizando o **Visual Studio 2022**. Seu objetivo é fornecer uma API para gerenciamento de filmes e gêneros, permitindo operações como criação, leitura, atualização e exclusão de dados.

O projeto segue uma arquitetura organizada em camadas, garantindo modularidade e facilidade de manutenção.





## 💀 Tecnologias Utilizadas
- **C#**
- **.NET Core / .NET 6+**
- **Entity Framework Core**
- **SQL Server**
- **Visual Studio 2022**



## 👾 Funcionalidades
- Cadastro de novos filmes
- Consulta de filmes por ID e por lista
- Atualização de informações de filmes
- Remoção de filmes do banco de dados



## 😶‍🌫️ Estrutura do Projeto
O projeto é composto por duas principais classes que representam as tabelas do banco de dados:




### 1. 🎬 Classe `Filmes`
Esta classe representa os filmes cadastrados na API, contendo informações como:
- ID do Filme
- Título
- ID do Gênero



### 2. 🎭 Classe `Generos`
Esta classe representa os gêneros dos filmes, armazenando:
- ID do gênero
- Nome do gênero




## 👩🏻‍💻 Banco de Dados
O banco de dados foi projetado para armazenar os filmes e seus respectivos gêneros, estabelecendo um relacionamento entre as tabelas `Filmes` e `Generos`.

O **Entity Framework Core** foi utilizado para gerenciar a comunicação com o banco de dados, permitindo a criação das tabelas e manipulação dos registros de forma eficiente.

# ⚠️ Como Executar o Projeto
1. Clone o repositório para sua máquina:
   ```sh
   https://github.com/aggiers/API_Filme.git

2. Abra o projeto no Visual Studio 2022.

3. Configure a string de conexão com o banco de dados no `appsettings.json`.

4. Execute as migrações do Entity Framework para criar as tabelas no banco:
   ```sh
   ADD-MIGRATION DB_name
   UPDATE-DATABASE
   ```

5. Incie a APi

A API estará disponível no seu navegador ou em um cliente de API como Postman ou Insomnia.

## 👻 Endpoints da API

A API fornece os seguintes endpoints para interação:

### **Filmes**

- `GET /api/filmes` - Lista todos os filmes

- `GET /api/filmes/{id}` - Obtém um filme por ID

- `POST /api/filmes` - Adiciona um novo filme

- `PUT /api/filmes/{id}` - Atualiza um filme existente

- `DELETE /api/filmes/{id}` - Remove um filme

### **Generos**

- `GET /api/generos` - Lista todos os gêneros

- `GET /api/generos/{id}` - Obtém um gênero por ID

- `POST /api/generos` - Adiciona um novo gênero

- `PUT /api/generos/{id}` - Atualiza um gênero existente

- `DELETE /api/generos/{id}` - Remove um gênero

## 🐥 Contribuição

Caso queira contribuir para este projeto, fique à vontade para abrir uma issue ou enviar um pull request.

## 📜 Licença

Este projeto está sob a licença MIT.










