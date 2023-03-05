using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.domain
{
    public class Payroll
    {

        public static Department GeneratePayroll(List<TimekeepingRecord> timekeepingRecords, string departmentName, string month, string year)
        {
            var department = new Department(departmentName, month, year);
            var employees = timekeepingRecords.Select(p => new Employee(p.Name, p.Code, p.HourlyRate)).Distinct().ToList();

            foreach (var employee in employees)
            {
                List<Record> records = new List<Record>();

                setEmployeeRecords(timekeepingRecords, employee, records);

                employee.Records = records;
                var employeePay = employee.CalculatePay();
                department.TotalPayroll += employeePay.TotalToReceive;
                department.TotalDiscounts += employeePay.TotalDiscounts;
                department.TotalExtraHours += employeePay.ExtraHours;


                department.EmployeesPay.Add(employeePay);
            }

            return department;
        }

        private static void setEmployeeRecords(List<TimekeepingRecord> timekeepingRecords, Employee? employee, List<Record> records)
        {
            foreach (TimekeepingRecord timekeepingRecord in timekeepingRecords.Where(p => p.Code == employee.Code))
            {
                Record record = new Record();

                // convert CheckIn and LunchBreak to DateTime
                DateTime checkInDateTime = timekeepingRecord.Date.Date + timekeepingRecord.CheckIn;
                DateTime lunchBreakEndDateTime = checkInDateTime.Add(timekeepingRecord.LunchBreak);

                // convert CheckOut to DateTime
                DateTime checkOutDateTime = timekeepingRecord.Date.Date + timekeepingRecord.CheckOut;

                record.StartTime = checkInDateTime;
                record.EndTime = checkOutDateTime;
                record.LunchHours = timekeepingRecord.LunchBreak.TotalHours;

                records.Add(record);
            }
        }
    }
}
