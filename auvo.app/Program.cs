using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using auvo.app.Services;
using auvo.domain;
using FileHelpers;
using Newtonsoft.Json;

namespace auvo.app
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            Console.Write("Informe o caminho da pasta: ");
            string pasta = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(pasta))
            {
                return;
            }

            DirectoryInfo diretorio = new DirectoryInfo(pasta);
            if (!diretorio.Exists)
            {
                Console.WriteLine($"O diretório '{pasta}' não existe.");
                return;
            }

            FileInfo[] arquivos = diretorio.GetFiles("*.csv");

            Parallel.ForEach(arquivos, arquivo =>
            {
                try
                {
                    Console.WriteLine($"Processando arquivo: {arquivo.Name}");
                    var tituloArquivo = arquivo.Name.Split('-');

                    var records = CsvFileService.LerRegistros(arquivo).Result;

                    if (records != null)
                    {
                        var departmento = Payroll.GeneratePayroll(records, tituloArquivo[0], tituloArquivo[1], tituloArquivo[2]);

                    }

                    Console.WriteLine($"* Processamento do arquivo: {arquivo.Name} finalizado. *");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao processar arquivo: {arquivo.Name}");
                }

            });
        }
    }

}
