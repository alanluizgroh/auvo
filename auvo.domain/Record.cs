using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.domain
{
    public class Record
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double LunchHours { get; set; }
    }
}
