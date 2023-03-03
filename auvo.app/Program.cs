using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileHelpers;
using Newtonsoft.Json;

namespace auvo.app
{
    class Program
    {
        static void Main(string[] args)
        {
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
                Console.WriteLine(arquivo.Name);
            });
        }
    }

}
