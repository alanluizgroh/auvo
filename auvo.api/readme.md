# API Auvo
Esta é uma API desenvolvida em C# que utiliza a biblioteca AutoMapper para fazer mapeamento de objetos. A aplicação utiliza o MongoDB como banco de dados.

## Configuração do Banco de Dados
A configuração do banco de dados pode ser encontrada no arquivo appsettings.json. Atualmente, o banco de dados utilizado é o MongoDB e as informações de conexão são as seguintes:


"StoreDatabase": {
    "ConnectionString": "mongodb+srv://admin:gQ0AhsZKAD8rPoXA@repository.4v5p3ir.mongodb.net/?retryWrites=true&w=majority",
    "DatabaseName": "Repository"
}

## Mapeamento de Objetos
A classe MappingConfig contém a configuração do AutoMapper para mapear objetos da classe DepartamentoVO para a classe Departamento e vice-versa. Esta classe é utilizada no construtor da classe RepositoryPayrollService.

## Serviços
A classe RepositoryPayrollService é responsável por fazer a comunicação com o banco de dados e executar as operações CRUD na coleção "Pagamento". Esta classe utiliza o MongoDB Driver para .NET.

## Os métodos disponíveis na API são:

### GET /api/Payroll
Retorna uma lista de todos os registros de pagamento de salário.

### POST /api/Payroll
Insere um novo registro de pagamento de salário.

## Swagger
A API utiliza Swagger para gerar uma teste interativo.