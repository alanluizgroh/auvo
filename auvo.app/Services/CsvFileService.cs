using auvo.model;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace auvo.app.Services
{
    public class CsvFileService
    {
        public static async Task<List<RegistroDePonto>> LerRegistros(FileInfo? arquivo)
        {

            
            var registros = new List<RegistroDePonto>();

            using (var reader = new StreamReader(arquivo.FullName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<RegistroMap>();
                registros = csv.GetRecords<RegistroDePonto>().ToList();

                // Processar os registros aqui
            }


            return registros;
        }
    }
}
