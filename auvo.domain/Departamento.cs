using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Departamento
    {
        [JsonProperty(PropertyName = "Departamento")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "MesVigencia")]
        public string MesVigencia { get; set; }

        [JsonProperty(PropertyName = "AnoVigencia")]
        public string AnoVigencia { get; set; }

        [JsonProperty(PropertyName = "TotalPagar")]
        public double TotalPagar { get; set; }

        [JsonProperty(PropertyName = "TotalDescontos")]
        public double TotalDescontos { get; set; }

        [JsonProperty(PropertyName = "TotalExtras")]
        public double TotalExtras { get; set; }

        [JsonProperty(PropertyName = "Funcionarios")]
        public IList<Funcionario> Funcionarios { get; set; }

        public Departamento(string departmentName, string month, string year)
        {
            Nome = departmentName;
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
