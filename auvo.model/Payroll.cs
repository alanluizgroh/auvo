using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.model
{
    /// <summary>
    ///  A classe RegistroHora contém os atributos que representam as informações de registro de hora. 
    ///  Note que na classe RegistroHora, a propriedade Funcionarios é uma lista de Funcionario, 
    ///  que representará os funcionários registrados em cada mês/ano.
    /// </summary>
    public class Payroll 
    {
        public string Departament { get; set; } = "";
        public string Month { get; set; } = "";
        public string Year { get; set; } = "";
        public double TotalPayroll { get; set; }
        public double TotalDiscounts { get; set; }
        public double TotalExtras { get; set; }
        public IList<Funcionario> EmployeesPay { get; private set; }

        //public Department Department { get; set; }
        //public string Month { get; set; }
        //public string Year { get; set; }
        //public double TotalPayroll { get; set; }
        //public double TotalDiscounts { get; set; }
        //public double TotalExtraHours { get; set; }
        //public IList<Employee> EmployeesPay { get; private set; }

    }
}
