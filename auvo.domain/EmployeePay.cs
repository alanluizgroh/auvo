using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class EmployeePay
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "WorkedDays")]
        public int WorkedDays { get; set; }

        [JsonProperty(PropertyName = "DaysOff")]
        public int DaysOff { get; set; }

        [JsonProperty(PropertyName = "TotalToReceive")]
        public double TotalToReceive { get; set; }

        [JsonProperty(PropertyName = "TotalDiscounts")]
        public double TotalDiscounts { get; set; }

        [JsonProperty(PropertyName = "ExtraHours")]
        public double ExtraHours { get; set; }
    }
}
