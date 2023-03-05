using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.domain
{
    public class EmployeePay
    {
        public string Name { get; set; }
        public int WorkedDays { get; set; }
        public int DaysOff { get; set; }
        public double TotalToReceive { get; set; }
        public double TotalDiscounts { get; set; }
        public double ExtraHours { get; set; }
    }
}
