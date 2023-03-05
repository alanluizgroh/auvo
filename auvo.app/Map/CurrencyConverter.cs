using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.app.Map
{
    public class CurrencyConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrEmpty(text))
                return base.ConvertFromString(text, row, memberMapData);

            text = text.Replace("R$ ", "").Replace(",", ".").Replace(" ", "");
            return decimal.Parse(text, CultureInfo.InvariantCulture);
        }
    }
}
