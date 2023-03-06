using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using auvo.app.Services;
using auvo.domain;
using FileHelpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace auvo.app
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

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
                        var departmento = Pagamento.GerarPagamento(records, tituloArquivo[0], tituloArquivo[1], tituloArquivo[2].Replace(".csv", ""));
                        PostDepartment(departmento).Wait();
                    }

                    Console.WriteLine($"* Processamento do arquivo: {arquivo.Name} finalizado. *");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao processar arquivo: {arquivo.Name}");
                }
            });

            Console.WriteLine("Processamento finalizado.");
            Console.WriteLine($"Os arquivos processados podem ser baixados em: https://localhost:7248/Home/Payroll");
            Console.ReadLine();
        }
        public static async Task PostDepartment(Departamento department)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7031/");

      

            var json = JsonConvert.SerializeObject(department);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/payroll", content);
            response.EnsureSuccessStatusCode();

            Task.WaitAll(response.Content.ReadAsStringAsync());

            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
        }
    }

  

}
