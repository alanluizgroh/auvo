using auvo.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using auvo.model;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace auvo.data.Data.ValueObjects
{
    public class RegistroHoraVO : RegistroDePonto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public RegistroHoraVO(int codigo, string nome, decimal valorHora, DateTime data, TimeSpan entrada, TimeSpan saida, TimeSpan almoco) : base(codigo, nome, valorHora, data, entrada, saida, almoco)
        {
        }
 
    }
}
