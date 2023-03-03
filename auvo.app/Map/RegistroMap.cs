using auvo.model;
using CsvHelper.Configuration;

public class RegistroMap : ClassMap<RegistroDePonto>
{
    public RegistroMap()
    {
        Map(m => m.Codigo).Name("Código");
        Map(m => m.Nome).Name("Nome");
        Map(m => m.ValorHora).Name("Valor hora");
        Map(m => m.Data).Name("Data");
        Map(m => m.Entrada).Name("Entrada");
        Map(m => m.Saida).Name("Saída");
        Map(m => m.Almoco).Name("Almoço");
    }
}