using auvo.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using auvo.model;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace auvo.api.Data.ValueObjects
{
    public class RegistroHoraVO : Payroll
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }


    }
}
