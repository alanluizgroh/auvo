using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.domain
{
    public class Payroll
    {


        public Payroll()
        {
            
        }

        public void ExportToFile(string fileName)
        {
            using (var writer = new StreamWriter(fileName))
            {
                writer.WriteLine("Folha de Pagamento");

                writer.WriteLine($"Departamento: {Department.Name}");
                writer.WriteLine($"Mês/Ano: {Month}/{Year}");

                writer.WriteLine("Funcionário - Salário - Horas Extras - Descontos - Salário Líquido");

                foreach (var employee in EmployeesPay)
                {
                    var employeePay = employee.CalculatePay();
                    var netPay = employeePay.TotalToReceive - employeePay.TotalDiscounts;

                    writer.WriteLine($"{employee.Name} - {employeePay.TotalToReceive.ToString("C")} - {employeePay.ExtraHours}h - {employeePay.TotalDiscounts.ToString("C")} - {netPay.ToString("C")}");
                }

                writer.WriteLine($"Total da folha de pagamento: {TotalPayroll.ToString("C")}");
                writer.WriteLine($"Total de descontos: {TotalDiscounts.ToString("C")}");
                writer.WriteLine($"Total de horas extras: {TotalExtraHours}h");
            }
        }
    }
}
