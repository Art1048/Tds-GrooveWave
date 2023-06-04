# Controle de Mesas de Restaurante

<img alt="Logo" align="right" src="https://www.utfpr.edu.br/icones/cabecalho/logo-utfpr/@@images/efcf9caf-6d29-4c24-8266-0b7366ea3a40.png" width="128" />

Esse é um projeto de cunho académico realizado na disciplina de Tecnologia em Desenvolvimento de Sistemas. O objetivo geral do projeto é construir uma aplicação que faca o gerenciamento e gestão de um restaurante com funcionalidade de cadastro de pedidos, produtos, categorização, disponibilidade de mesas, gestão de garcons entre outros. O projeto foi construído em C# utilizando Entity Framework com um banco de dados em memória (SQLite), Razor Pages com engine de renderização para o frontend e a biblioteca de estilização CSS chamada Tailwind.

### Estrutura de pastas do projeto

```javascript
├── Makefile
├── Restaurant.sln
├── app.db
├── readme.md
└── src
    ├── Restaurant.Api
    │   ├── Controllers
    │   │   ├── CategoryController
    │   │   │   └── CategoryController.cs
    │   │   ├── ProductController
    │   │   │   └── ProductController.cs
    │   │   ├── ServiceController
    │   │   │   └── ServiceController.cs
    │   │   ├── ServiceLineController
    │   │   │   └── ServiceLineController.cs
    │   │   ├── TableController
    │   │   │   └── TableController.cs
    │   │   └── WaiterController
    │   │       └── WaiterController.cs
    │   ├── Program.cs
    │   ├── Properties
    │   │   └── launchSettings.json
    │   ├── Restaurant.Api.csproj
    │   ├── appsettings.Development.json
    │   └── appsettings.json
    ├── Restaurant.Data
    │   ├── Data
    │   │   ├── DbContext.cs
    │   │   ├── Models
    │   │   │   ├── CategoryModel.cs
    │   │   │   ├── ProductModel.cs
    │   │   │   ├── ServiceLineModel.cs
    │   │   │   ├── ServiceModel.cs
    │   │   │   ├── Shared
    │   │   │   │   └── Entity.cs
    │   │   │   ├── TableModel.cs
    │   │   │   └── WaiterModel.cs
    │   │   └── Repository
    │   │       ├── CategoryRepository.cs
    │   │       ├── ProductRepository.cs
    │   │       ├── ServiceLineRepository.cs
    │   │       ├── ServiceRepository.cs
    │   │       ├── Shared
    │   │       │   ├── IRepositoryBase.cs
    │   │       │   └── RepositoryBase.cs
    │   │       ├── TableRepository.cs
    │   │       └── WaiterRepository.cs
    │   ├── Migrations
    │   │   ├── 20230417125107_InitialCreation.Designer.cs
    │   │   ├── 20230417125107_InitialCreation.cs
    │   │   └── ContextModelSnapshot.cs
    │   └── Restaurant.Data.csproj
    └── Restaurant.View
        ├── Pages
        │   ├── CloseService
        │   │   ├── Index.cshtml
        │   │   └── Index.cshtml.cs
        │   ├── Components
        │   │   ├── ConfigurationMenu
        │   │   │   ├── ConfigurationMenu.cs
        │   │   │   └── Default.cshtml
        │   │   ├── Footer
        │   │   │   ├── Default.cshtml
        │   │   │   └── Footer.cs
        │   │   └── Header
        │   │       ├── Default.cshtml
        │   │       └── Header.cs
        │   ├── Configurations
        │   │   ├── Categories
        │   │   │   ├── Create.cshtml
        │   │   │   ├── Create.cshtml.cs
        │   │   │   ├── Delete.cshtml
        │   │   │   ├── Delete.cshtml.cs
        │   │   │   ├── Edit.cshtml
        │   │   │   ├── Edit.cshtml.cs
        │   │   │   ├── Index.cshtml
        │   │   │   └── Index.cshtml.cs
        │   │   ├── Index.cshtml
        │   │   ├── Index.cshtml.cs
        │   │   ├── Products
        │   │   │   ├── Create.cshtml
        │   │   │   ├── Create.cshtml.cs
        │   │   │   ├── Delete.cshtml
        │   │   │   ├── Delete.cshtml.cs
        │   │   │   ├── Edit.cshtml
        │   │   │   ├── Edit.cshtml.cs
        │   │   │   ├── Index.cshtml
        │   │   │   └── Index.cshtml.cs
        │   │   ├── Tables
        │   │   │   ├── Create.cshtml
        │   │   │   ├── Create.cshtml.cs
        │   │   │   ├── Delete.cshtml
        │   │   │   ├── Delete.cshtml.cs
        │   │   │   ├── Edit.cshtml
        │   │   │   ├── Edit.cshtml.cs
        │   │   │   ├── Index.cshtml
        │   │   │   └── Index.cshtml.cs
        │   │   └── Waiters
        │   │       ├── Create.cshtml
        │   │       ├── Create.cshtml.cs
        │   │       ├── Delete.cshtml
        │   │       ├── Delete.cshtml.cs
        │   │       ├── Edit.cshtml
        │   │       ├── Edit.cshtml.cs
        │   │       ├── Index.cshtml
        │   │       └── Index.cshtml.cs
        │   ├── Index.cshtml
        │   ├── Index.cshtml.cs
        │   ├── OrderDetails
        │   │   ├── Index.cshtml
        │   │   └── Index.cshtml.cs
        │   ├── Orders
        │   │   ├── Index.cshtml
        │   │   └── Index.cshtml.cs
        │   ├── Shared
        │   │   └── _Layout.cshtml
        │   ├── _Imports.razor
        │   └── _ViewStart.cshtml
        ├── Program.cs
        ├── Properties
        │   └── launchSettings.json
        ├── Restaurant.View.csproj
        ├── appsettings.json
        ├── tailwind.config.js
        └── wwwroot
            └── images
                └── logo.png

```

### Como rodar o projeto

- O primeiro passo é verificar a existência dos arquivos `app.db`, `app.db-shm`, `app.db-wal`. Caso os mesmos existam é necessário excluir.
- O segundo passo é utilizar o comando `dotnet restore` na raiz da solução para baixar as dependências de todos os projetos.
- O segundo passo é semelhante ao primeiro, porém é realizado na pasta `src/Restaurant.Data/Migrations`. Nela deve-se realizar a exclusão de todos arquivos com a exceção do arquivo `.gitkeep`
- O próximo passo é executar as _migrations_ e para isso você precisa rodar o comando `dotnet ef database update -s ../Restaurant.Api` dentro da pasta `src/Restaurant.Data`.
- Por último utilize o comando `dotnet watch run` dentro da pasta `src/Restaurant.Api` ou apenas `dotnet run` para iniciar a aplicação e também na pasta `src/Restaurant.View` que irá inicializar o frontend.
