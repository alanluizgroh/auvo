using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.domain
{
    public class FuncionarioPagamento
    {
        public int Codigo { get; }
        public string Nome { get; }
        public double ValorHora { get; }
        public IEnumerable<Registro> Registros { get; set; }

        public FuncionarioPagamento(string name, int code, double hourlyRate)
        {
            Nome = name;
            Codigo = code;
            ValorHora = hourlyRate;

        }

        public Funcionario CalcularPagamento()
        {
            var workedDays = GetDiasTrabalhados();
            var daysOff = CalcularFaltas(workedDays);

            var employeePay = new Funcionario()
            {
                Codigo = this.Codigo,
                Nome = this.Nome,
                TotalReceber = CalcularTotalAReceber(),
                HorasDebito = CalcularTotalDescontos(),
                HorasExtras = CalcularHorasExtras(),
                DiasTrabalhados = workedDays.Count(),
                DiasFalta = daysOff
            };

            return employeePay;
        }

        private IEnumerable<DateTime> GetDiasTrabalhados()
        {
            return Registros.Where(r => r.Inicio != null && r.Fim != null)
                          .Select(r => r.Inicio.Value.Date);
        }

        private int CalcularFaltas(IEnumerable<DateTime> workedDays)
        {
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var totalWorkedDays = workedDays.Count();
            var totalDaysOfMonth = (lastDayOfMonth - firstDayOfMonth).Days + 1;

            return totalDaysOfMonth - totalWorkedDays;
        }

        private double CalcularTotalAReceber()
        {
            return Registros.Where(r => r.Inicio != null && r.Fim != null)
                          .Sum(r => CalcularHorasTrabalhadas(r) <= 8 ? CalcularHorasTrabalhadas(r) * ValorHora : 8 * ValorHora + (CalcularHorasTrabalhadas(r) - 8) * ValorHora * 1.5);
        }

        private double CalcularTotalDescontos()
        {
            return Registros.Where(r => r.Inicio != null && r.Fim != null)
                          .Sum(r => CalcularHorasTrabalhadas(r) < 8 ? (8 - CalcularHorasTrabalhadas(r)) * ValorHora : 0);
        }

        private double CalcularHorasTrabalhadas(Registro record)
        {
            return record.Fim.Value.Subtract(record.Inicio.Value).TotalHours - record.AlmocoHoras;
        }

        private double CalcularHorasExtras()
        {
            double extraHours = 0;

            foreach (var record in Registros)
            {
                var workedHours = CalcularHorasTrabalhadas(record);
                extraHours += (workedHours > 8 ? workedHours - 8 : 0);
            }

            return extraHours;
        }
    }


}
