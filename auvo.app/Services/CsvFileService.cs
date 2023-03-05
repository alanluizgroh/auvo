using auvo.domain;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace auvo.app.Services
{
    public class CsvFileService
    {
        public static async Task<List<TimekeepingRecord>> LerRegistros(FileInfo? arquivo)
        {

            var records = new List<TimekeepingRecord>();
            var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                Encoding = Encoding.UTF8 // set the encoding to match your file
            };

            using (var reader = new StreamReader(arquivo.FullName, Encoding.GetEncoding("iso-8859-1")))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<CsvRecordMap>();
                
                records = csv.GetRecords<TimekeepingRecord>().ToList();

            }

            return records;
        }


    }
}
