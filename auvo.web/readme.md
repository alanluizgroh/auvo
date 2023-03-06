# Aplicação ASP.NET MVC auvo.web
Esta é uma aplicação ASP.NET MVC que consome uma API REST para exibir informações sobre a folha de pagamento dos funcionários de uma empresa.

## Tecnologias utilizadas
+ ASP.NET MVC
+ C#
+ HttpClient
+ Newtonsoft.Json

## Como executar a aplicação
Para executar esta aplicação, siga os seguintes passos:

+ Clone este repositório em sua máquina local.
+ Abra o projeto em seu IDE favorito (por exemplo, Visual Studio).
+ Execute a aplicação pressionando F5.

## Estrutura do projeto
O projeto está estruturado da seguinte forma:

+ Controllers: Contém os controladores da aplicação, que lidam com as solicitações HTTP.
+ Services: Contém a definição da interface IAlvoApiClient e a implementação da classe AlvoApiClient, que consome a API REST.
+ Models: Contém as classes de modelo da aplicação.
+ Views: Contém as visualizações da aplicação.

### O controller principal da aplicação é o HomeController, que possui as seguintes ações:

+ Index: Exibe a página inicial.
+ About: Exibe informações requisitadas no teste.
+ Payroll: Exibe informações sobre a folha de pagamento.
+ Download: Faz o download de um arquivo JSON contendo os dados dos departamentos da empresa.