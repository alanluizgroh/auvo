using AutoMapper;
using auvo.api.Data.ValueObjects;
using auvo.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.api.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<RegistroHoraVO, RegistroDePonto>();
                config.CreateMap<RegistroDePonto, RegistroHoraVO>();
            });
            return mappingConfig;
        }
    }
}
