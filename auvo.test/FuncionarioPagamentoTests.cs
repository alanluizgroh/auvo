using Microsoft.Win32;
using System;
using System.Collections.Generic;
using Xunit;

namespace auvo.domain.tests
{
    public class FuncionarioPagamentoTests
    {
        [Fact]
        public void CalcularPagamento_ShouldCalculateEmployeePay()
        {
            // Arrange
            var employee = new FuncionarioPagamento("John", 123, 10.0);
            employee.Registros = new List<Registro>
            {
                new Registro
                {
                    Inicio = new DateTime(2023, 03, 07, 8, 0, 0),
                    Fim = new DateTime(2023, 03, 07, 17, 0, 0),
                    AlmocoHoras = 1
                },
                new Registro
                {
                    Inicio = new DateTime(2023, 03, 08, 8, 0, 0),
                    Fim = new DateTime(2023, 03, 08, 16, 0, 0),
                    AlmocoHoras = 1
                }
            };

            // Act
            var result = employee.CalcularPagamento();

            // Assert
            Assert.Equal("John", result.Nome);
            Assert.Equal(123, result.Codigo);
            Assert.Equal(150.0, result.TotalReceber, 2);
            Assert.Equal(10.0, result.HorasDebito, 2);
            Assert.Equal(0, result.HorasExtras, 2);
            Assert.Equal(2, result.DiasTrabalhados);
            Assert.Equal(29, result.DiasFalta);
            Assert.Equal(0, result.DiasExtras);
        }
    }
}
