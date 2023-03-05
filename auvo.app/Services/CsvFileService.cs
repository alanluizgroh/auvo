using auvo.domain;
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
        public static async Task<List<TimekeepingRecord>> LerRegistros(FileInfo? arquivo)
        {

            var records = new List<TimekeepingRecord>();

            using (var reader = new StreamReader(arquivo.FullName))
            using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
            {
                csv.Context.RegisterClassMap<CsvRecordMap>();

                var headers = csv.HeaderRecord;
                var expectedHeaders = new[] { "Código", "Nome", "Valor hora", "Data", "Entrada", "Saída", "Almoço" };

                if (headers.SequenceEqual(expectedHeaders))
                {
                    records = csv.GetRecords<TimekeepingRecord>().ToList();
                    
                }
            }

            return records;
        }


    }
}
