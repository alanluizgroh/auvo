using auvo.domain;


namespace auvo.web.Services
{
    public class AlvoApiClient : IAlvoApiClient
    {
        private readonly HttpClient _httpClient;

        public AlvoApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Departamento>> GetDepartmentsAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7031/api/payroll");
            response.EnsureSuccessStatusCode();
            var departments = await response.Content.ReadAsAsync<List<Departamento>>();
            return departments;
        }
    }
}
