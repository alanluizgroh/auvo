using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Funcionario
    {
        

        [JsonProperty(PropertyName = "Nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "Codigo")]
        public int Codigo { get; set; }

        [JsonProperty(PropertyName = "TotalReceber")]
        public double TotalReceber { get; set; }

        [JsonProperty(PropertyName = "HorasExtras")]
        public double HorasExtras { get; set; }

        [JsonProperty(PropertyName = "HorasDebito")]
        public double HorasDebito { get; set; }

        [JsonProperty(PropertyName = "DiasFalta")]
        public int DiasFalta { get; set; }

        [JsonProperty(PropertyName = "DiasExtras")]
        public int DiasExtras { get; set; }

        [JsonProperty(PropertyName = "DiasTrabalhados")]
        public int DiasTrabalhados { get; set; }

    }
}
