#Auvo
O Auvo é uma solução composta por cinco projetos:

+ auvo.api: projeto responsável pela implementação da API RESTful que fornece dados de funcionários e departamentos. Foi construído com o framework ASP.NET Core e utiliza o MongoDbDriver para acesso aos dados.

+ auvo.app: projeto responsável pela implementação da lógica de negócio da aplicação. Utiliza o framework .NET e implementa interfaces para comunicação com a API RESTful e persistência de dados.

+ auvo.domain: projeto responsável pela definição das entidades e modelos de negócio da aplicação. É um projeto .NET e é compartilhado entre a camada de aplicação e a camada de API.

+ auvo.web: projeto responsável pela implementação da interface gráfica da aplicação web. Foi construído com o framework ASP.NET Core e utiliza o Razor para a construção das views.

+ auvo.test: projeto responsável pelos testes unitários da aplicação. Utiliza o framework xUnit para a escrita dos testes e implementa testes para a camada de aplicação e de API.

### A arquitetura da solução segue o padrão de arquitetura em camadas, separando as responsabilidades em diferentes projetos e facilitando a manutenção e evolução do sistema.