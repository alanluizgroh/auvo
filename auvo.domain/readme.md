# Descrição do código
Este código contém três classes do namespace "auvo.domain", que são:

* Departamento
* Funcionario
* FuncionarioPagamento
* Departamento
* A classe Departamento representa um departamento dentro de uma empresa e possui as seguintes propriedades:

Nome: o nome do departamento.
MesVigencia: o mês da vigência do departamento.
AnoVigencia: o ano da vigência do departamento.
TotalPagar: o valor total a ser pago pelo departamento.
TotalDescontos: o valor total de descontos do departamento.
TotalExtras: o valor total de horas extras do departamento.
Funcionarios: uma lista de funcionários que fazem parte do departamento.
Além disso, a classe possui um construtor que recebe o nome do departamento, o mês e o ano da vigência como parâmetros e inicializa as propriedades TotalPagar, TotalDescontos e TotalExtras como zero e a propriedade Funcionarios como uma lista vazia.

# Funcionario
A classe Funcionario representa um funcionário de uma empresa e possui as seguintes propriedades:

Nome: o nome do funcionário.
Codigo: o código do funcionário.
TotalReceber: o valor total a receber pelo funcionário.
HorasExtras: o número de horas extras trabalhadas pelo funcionário.
HorasDebito: o número de horas em débito do funcionário.
DiasFalta: o número de dias de falta do funcionário.
DiasExtras: o número de dias de horas extras trabalhadas pelo funcionário.
DiasTrabalhados: o número de dias trabalhados pelo funcionário.
FuncionarioPagamento
A classe FuncionarioPagamento representa o cálculo de pagamento de um funcionário e possui as seguintes propriedades:

Nome: o nome do funcionário.
Codigo: o código do funcionário.
ValorHora: o valor da hora do funcionário.
Registros: uma lista de registros de horário do funcionário.
Além disso, a classe possui um construtor que recebe o nome do funcionário, o código e o valor da hora como parâmetros.

A classe possui um método CalcularPagamento que retorna um objeto Funcionario com o cálculo de pagamento do funcionário com base nos registros de horário armazenados em Registros.

O método utiliza os métodos privados GetDiasTrabalhados, CalcularFaltas, CalcularTotalAReceber, CalcularTotalDescontos, CalcularHorasExtras e CalcularHorasTrabalhadas para calcular o número de dias trabalhados, o número de dias de falta, o valor total a receber, o valor total de descontos, o número de horas extras trabalhadas e o número de horas trabalhadas em cada registro de horário.

Tecnologias utilizadas
C#
Newtonsoft.Json