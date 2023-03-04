using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.domain
{
    public class Employee
    {
        public int Code { get; }
        public string Name { get; }
        public double HourlyRate { get; }
        public IEnumerable<Record> Records { get; set; }

        public Employee(string name, int code, double hourlyRate)
        {
            Name = name;
            Code = code;
            HourlyRate = hourlyRate;

        }

        public EmployeePay CalculatePay()
        {
            var workedDays = GetWorkedDays();
            var daysOff = CalculateDaysOff(workedDays);

            var employeePay = new EmployeePay()
            {
                Employee = this,
                TotalToReceive = CalculateTotalToReceive(),
                TotalDiscounts = CalculateTotalDiscounts(),
                ExtraHours = CalculateExtraHours(),
                WorkedDays = workedDays.Count(),
                DaysOff = daysOff
            };

            return employeePay;
        }

        private IEnumerable<DateTime> GetWorkedDays()
        {
            return Records.Where(r => r.StartTime != null && r.EndTime != null)
                          .Select(r => r.StartTime.Value.Date);
        }

        private int CalculateDaysOff(IEnumerable<DateTime> workedDays)
        {
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var totalWorkedDays = workedDays.Count();
            var totalDaysOfMonth = (lastDayOfMonth - firstDayOfMonth).Days + 1;

            return totalDaysOfMonth - totalWorkedDays;
        }

        private double CalculateTotalToReceive()
        {
            return Records.Where(r => r.StartTime != null && r.EndTime != null)
                          .Sum(r => CalculateWorkedHours(r) <= 8 ? CalculateWorkedHours(r) * HourlyRate : 8 * HourlyRate + (CalculateWorkedHours(r) - 8) * HourlyRate * 1.5);
        }

        private double CalculateTotalDiscounts()
        {
            return Records.Where(r => r.StartTime != null && r.EndTime != null)
                          .Sum(r => CalculateWorkedHours(r) < 8 ? (8 - CalculateWorkedHours(r)) * HourlyRate : 0);
        }

        private double CalculateWorkedHours(Record record)
        {
            return record.EndTime.Value.Subtract(record.StartTime.Value).TotalHours - record.LunchHours;
        }

        private double CalculateExtraHours()
        {
            double extraHours = 0;

            foreach (var record in Records)
            {
                var workedHours = CalculateWorkedHours(record);
                extraHours += (workedHours > 8 ? workedHours - 8 : 0);
            }

            return extraHours;
        }
    }


}
