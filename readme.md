#Auvo
O Auvo � uma solu��o composta por cinco projetos:

+ auvo.api: projeto respons�vel pela implementa��o da API RESTful que fornece dados de funcion�rios e departamentos. Foi constru�do com o framework ASP.NET Core e utiliza o MongoDbDriver para acesso aos dados.

+ auvo.app: projeto respons�vel pela implementa��o da l�gica de neg�cio da aplica��o. Utiliza o framework .NET e implementa interfaces para comunica��o com a API RESTful e persist�ncia de dados.

+ auvo.domain: projeto respons�vel pela defini��o das entidades e modelos de neg�cio da aplica��o. � um projeto .NET e � compartilhado entre a camada de aplica��o e a camada de API.

+ auvo.web: projeto respons�vel pela implementa��o da interface gr�fica da aplica��o web. Foi constru�do com o framework ASP.NET Core e utiliza o Razor para a constru��o das views.

+ auvo.test: projeto respons�vel pelos testes unit�rios da aplica��o. Utiliza o framework xUnit para a escrita dos testes e implementa testes para a camada de aplica��o e de API.

### A arquitetura da solu��o segue o padr�o de arquitetura em camadas, separando as responsabilidades em diferentes projetos e facilitando a manuten��o e evolu��o do sistema.