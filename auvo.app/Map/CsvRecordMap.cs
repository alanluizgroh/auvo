using auvo.app.Map;
using auvo.domain;
using CsvHelper.Configuration;
using System.Globalization;

public class CsvRecordMap : ClassMap<RegistroPonto>
{
    public CsvRecordMap()
    {
        Map(m => m.Codigo).Name("Código");
        Map(m => m.Nome).Name("Nome");
        Map(m => m.ValorHora).Name("Valor hora").TypeConverter<CurrencyConverter>();
        Map(m => m.Data).Name("Data").TypeConverterOption.Format("dd/MM/yyyy");
        Map(m => m.Inicio).Name("Entrada").TypeConverterOption.Format("hh\\:mm\\:ss");
        Map(m => m.Fim).Name("Saída").TypeConverterOption.Format("hh\\:mm\\:ss");
        Map(m => m.Almoco).Name("Almoço").TypeConverter<LunchBreakConverter>();
    }
}



