using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.domain
{
    public class Departamento
    {
        public string DepartamentoNome { get; set; }

        public string MesVigencia { get; set; }

        public string AnoVigencia { get; set; }

        public double TotalPagar { get; set; }

        public double TotalDescontos { get; set; }

        public double TotalExtras { get; set; }

        public IList<Funcionario> Funcionarios { get; set; }

        public Departamento(string departmentName, string month, string year)
        {
            DepartamentoNome = departmentName;
            MesVigencia = month;
            AnoVigencia = year;
            TotalPagar = 0;
            TotalDescontos = 0;
            TotalExtras = 0;
            Funcionarios = new List<Funcionario>();
        }

        public Departamento() { }

    }
}
