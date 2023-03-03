using AutoMapper;
using auvo.data.Data.ValueObjects;
using auvo.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.data.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<RegistroHoraVO, RegistroHora>();
                config.CreateMap<RegistroHora, RegistroHoraVO>();
            });
            return mappingConfig;
        }
    }
}
