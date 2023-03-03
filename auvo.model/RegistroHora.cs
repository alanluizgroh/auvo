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
    public class RegistroHora : BaseEntity
    {
        public string Departamento { get; set; } = "";
        public string MesVigencia { get; set; } = "";
        public int AnoVigencia { get; set; }
        public double TotalPagar { get; set; }
        public double TotalDescontos { get; set; }
        public double TotalExtras { get; set; }
        public List<Funcionario>? Funcionarios { get; set; }

    }
}
