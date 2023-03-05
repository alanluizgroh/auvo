using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.domain
{
    public class TimekeepingRecord
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public decimal HourlyRate { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan CheckIn { get; set; }
        public TimeSpan CheckOut { get; set; }
        public TimeSpan LunchBreak { get; set; }

        public TimekeepingRecord() { }
        public TimekeepingRecord(int code, string name, decimal hourlyRate, DateTime date, TimeSpan checkIn, TimeSpan checkOut, TimeSpan lunchBreak)
        {
            Code = code;
            Name = name;
            HourlyRate = hourlyRate;
            Date = date;
            CheckIn = checkIn;
            CheckOut = checkOut;
            LunchBreak = lunchBreak;
        }
    }
}
