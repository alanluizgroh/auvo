
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.model
{
    /// <summary>
    /// Nessa implementação, cada propriedade da classe representa um dos dados do registro de ponto: 
    /// Codigo, Nome, ValorHora, Data, Entrada, Saida e Almoco. 
    /// O construtor da classe recebe todos esses dados como parâmetros e os utiliza para inicializar 
    /// as propriedades correspondentes.
    /// </summary>
    public class RegistroDePonto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal ValorHora { get; set; }
        public DateTime Data { get; set; }

        /// <summary>
        /// Note que para inicializar as propriedades Entrada, Saida e Almoco foram utilizados 
        /// objetos do tipo TimeSpan, que representam um intervalo de tempo 
        /// (no caso, a hora/minuto/segundo de cada um desses eventos).
        /// </summary>
        public TimeSpan Entrada { get; set; }
        public TimeSpan Saida { get; set; }
        public TimeSpan Almoco { get; set; }

        public RegistroDePonto(int codigo, string nome, decimal valorHora, DateTime data, TimeSpan entrada, TimeSpan saida, TimeSpan almoco)
        {
            Codigo = codigo;
            Nome = nome;
            ValorHora = valorHora;
            Data = data;
            Entrada = entrada;
            Saida = saida;
            Almoco = almoco;
        }
    }
}
