using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.domain
{
    public class RegistroPonto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal ValorHora { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fim { get; set; }
        public TimeSpan Almoco { get; set; }

        public RegistroPonto() { }
        public RegistroPonto(int code, string name, decimal hourlyRate, DateTime date, TimeSpan checkIn, TimeSpan checkOut, TimeSpan lunchBreak)
        {
            Codigo = code;
            Nome = name;
            ValorHora = hourlyRate;
            Data = date;
            Inicio = checkIn;
            Fim = checkOut;
            Almoco = lunchBreak;
        }
    }
}
