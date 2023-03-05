﻿using auvo.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace auvo.api.Data.ValueObjects
{
    public class DepartmentVO : Department
    {
        public DepartmentVO() { }
        public DepartmentVO(string name, string month, string year) : base(name, month, year)
        {
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }


    }
}