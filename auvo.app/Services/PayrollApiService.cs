using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using auvo.domain;

namespace auvo.app.Services
{
    public class PayrollApiService
    {
        private readonly string _apiUrl = "https://localhost:7031/";

        public PayrollApiService()
        {

        }

        public async Task PostDepartmentAsync(Department department)
        {
            try
            {
                using var client = new HttpClient();

                // Set the API URL
                client.BaseAddress = new Uri(_apiUrl);

                // Set the request headers
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Create the POST request body
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(department));

                // Send the POST request and retrieve the response
                var response = await client.PostAsync("api/payroll", content);

                // Throw an exception if the response status code indicates an error
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar departmento {department.Name} para a API: {ex.Message}");
            }
        }
    }
}
