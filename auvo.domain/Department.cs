using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.domain
{
    public class Department
    {
        public string Name { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public double TotalPayroll { get; set; }
        public double TotalDiscounts { get; set; }
        public double TotalExtraHours { get; set; }
        public IList<EmployeePay> EmployeesPay { get; private set; }

        public Department(string name, string month, string year)
        {
            Name = name;
            Month = month;
            Year = year;
            TotalPayroll = 0;
            TotalDiscounts = 0;
            TotalExtraHours = 0;
        }


      
    }
}
