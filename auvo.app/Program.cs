using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
                    var payroll = new Payroll();
                    Console.WriteLine($"Processando arquivo: {arquivo.Name}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao processar arquivo: {arquivo.Name}");
                }

            });
        }
    }

}
