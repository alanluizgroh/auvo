using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.app.Map
{
    public class LunchBreakConverter : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            var parts = text.Split('-');
            var startTime = TimeSpan.Parse(parts[0].Trim());
            var endTime = TimeSpan.Parse(parts[1].Trim());
            return endTime - startTime;
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            throw new NotImplementedException();
        }
    }
}
