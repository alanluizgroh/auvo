using auvo.app.Map;
using auvo.domain;
using CsvHelper.Configuration;
using System.Globalization;

public class CsvRecordMap : ClassMap<TimekeepingRecord>
{
    public CsvRecordMap()
    {
        Map(m => m.Code).Name("Código");
        Map(m => m.Name).Name("Nome");
        Map(m => m.HourlyRate).Name("Valor hora").TypeConverter<CurrencyConverter>();
        Map(m => m.Date).Name("Data").TypeConverterOption.Format("dd/MM/yyyy");
        Map(m => m.CheckIn).Name("Entrada").TypeConverterOption.Format("hh\\:mm\\:ss");
        Map(m => m.CheckOut).Name("Saída").TypeConverterOption.Format("hh\\:mm\\:ss");
        Map(m => m.LunchBreak).Name("Almoço").TypeConverter<LunchBreakConverter>();
    }
}



