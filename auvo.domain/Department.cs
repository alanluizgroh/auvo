using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Department
    {
        [JsonProperty(PropertyName = "Departamento")]
        public string DepartmentName { get; set; }

        [JsonProperty(PropertyName = "Month")]
        public string Month { get; set; }

        [JsonProperty(PropertyName = "Year")]
        public string Year { get; set; }

        [JsonProperty(PropertyName = "TotalPayroll")]
        public double TotalPayroll { get; set; }

        [JsonProperty(PropertyName = "TotalDiscounts")]
        public double TotalDiscounts { get; set; }

        [JsonProperty(PropertyName = "TotalExtraHours")]
        public double TotalExtraHours { get; set; }

        [JsonProperty(PropertyName = "EmployeesPay")]
        public IList<EmployeePay> EmployeesPay { get; set; }

        public Department(string departmentName, string month, string year)
        {
            DepartmentName = departmentName;
            Month = month;
            Year = year;
            TotalPayroll = 0;
            TotalDiscounts = 0;
            TotalExtraHours = 0;
            EmployeesPay = new List<EmployeePay>();
        }

        public Department() { }

    }
}
