using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.domain
{
    public class Pagamento
    {

        public static Departamento GerarPagamento(List<RegistroPonto> timekeepingRecords, string departmentName, string month, string year)
        {
            var department = new Departamento(departmentName, month, year);
            var employees = timekeepingRecords.GroupBy(r => new { r.Codigo, r.Nome, r.ValorHora })
                            .Select(g => new FuncionarioPagamento(g.Key.Nome, g.Key.Codigo, (double)g.Key.ValorHora)).ToList();

            foreach (var employee in employees)
            {
                List<Registro> records = new List<Registro>();

                setRegistros(timekeepingRecords, employee, records);

                employee.Registros = records;
                var employeePay = employee.CalcularPagamento();
                department.TotalPagar += employeePay.TotalReceber;
                department.TotalDescontos += employeePay.HorasDebito;
                department.TotalExtras += employeePay.HorasExtras;


                department.Funcionarios.Add(employeePay);
            }

            return department;
        }

        private static void setRegistros(List<RegistroPonto> timekeepingRecords, FuncionarioPagamento? employee, List<Registro> records)
        {
            foreach (RegistroPonto timekeepingRecord in timekeepingRecords.Where(p => p.Codigo == employee.Codigo))
            {
                Registro record = new Registro();

                // convert CheckIn and LunchBreak to DateTime
                DateTime checkInDateTime = timekeepingRecord.Data.Date + timekeepingRecord.Inicio;
                DateTime lunchBreakEndDateTime = checkInDateTime.Add(timekeepingRecord.Almoco);

                // convert CheckOut to DateTime
                DateTime checkOutDateTime = timekeepingRecord.Data.Date + timekeepingRecord.Fim;

                record.Inicio = checkInDateTime;
                record.Fim = checkOutDateTime;
                record.AlmocoHoras = timekeepingRecord.Almoco.TotalHours;

                records.Add(record);
            }
        }
    }
}
