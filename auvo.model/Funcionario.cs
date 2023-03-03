using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.model
{
    /// <summary>
    /// A classe Funcionario contém os atributos que representam as informações de cada funcionário.
    /// </summary>
    public class Funcionario : BaseEntity
    {
        
        public int Codigo { get; set; }
        public string Nome { get; set; } = "";
        public double TotalReceber { get; set; }
        public double HorasExtras { get; set; }
        public double HorasDebito { get; set; }
        public int DiasFalta { get; set; }
        public int DiasExtras { get; set; }
        public int DiasTrabalhados { get; set; }
    }

    public class EmployeePay
    {
        public Employee Employee { get; set; }
        public int WorkedDays { get; set; }
        public int DaysOff { get; set; }
        public double TotalToReceive { get; set; }
        public double TotalDiscounts { get; set; }
        public double ExtraHours { get; set; }
    }
}
