using auvo.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.biz
{

    public class RegistroHoraBuilder
    {
        public Payroll Build(List<RegistroDePonto> registros, string fileName)
        {
            var header = fileName.Split('-');
            var registroHora = new Payroll
            {
                Departament = header[0],
                Month = header[1],
                Year = header[2]
            };

            var registrosPorFuncionario = registros.Select(p => p.Nome).Distinct();

    
            foreach (var nomeFuncionario in registrosPorFuncionario)
            {
                Funcionario funcionario = new Funcionario();

                var registrosFuncionario = registros.Where(p => p.Nome == nomeFuncionario);
                funcionario.Nome = registrosFuncionario.First().Nome;
                funcionario.Codigo = registrosFuncionario.First().Codigo;

                double valorHora = (double)registrosFuncionario.First().ValorHora;
                double horasTrabalhadas = 0;
                double horasExtras = 0;
                double horasDebito = 0;
                int diasExtras = 0;
                int diasFalta = 0;
                double totalPagar = 0;
                double totalDescontos = 0;

         
                foreach (var registro in registrosFuncionario)
                {
                    horasTrabalhadas += (registro.Saida - registro.Entrada - registro.Almoco).TotalHours ;

                    if (horasTrabalhadas > 8)
                    {
                        horasExtras += horasTrabalhadas - 8;
                        horasTrabalhadas = 8;
                    }
                    else if (horasTrabalhadas < 8)
                    {
                        horasDebito += 8 - horasTrabalhadas;
                        horasTrabalhadas = 8;
                    }

                    if (registro.Entrada != new TimeSpan(8, 0, 0))
                    {
                        diasFalta++;
                    }

                    if (registro.Saida > new TimeSpan(17, 0, 0))
                    {
                        diasExtras++;
                    }

                    totalPagar += horasTrabalhadas * valorHora;
                }

                totalDescontos = (double)(horasDebito * valorHora);

                funcionario.TotalReceber = totalPagar;
                funcionario.HorasExtras = horasExtras;
                funcionario.HorasDebito = horasDebito;
                funcionario.DiasFalta = diasFalta;
                funcionario.DiasExtras = diasExtras;
                funcionario.DiasTrabalhados = registros.Count;

              
                registroHora.TotalPayroll += totalPagar;
                registroHora.TotalDiscounts += totalDescontos;
                registroHora.TotalExtras += horasExtras;

                registroHora.EmployeesPay.Add(funcionario);
            }

            return registroHora;
        }
    }
}
