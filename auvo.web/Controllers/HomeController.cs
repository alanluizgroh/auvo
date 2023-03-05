using auvo.web.Models;
using auvo.web.Services;
using auvo.web.Util;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using System.Text;

namespace auvo.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAlvoApiClient _alvoApiClient;




        public HomeController(ILogger<HomeController> logger, IAlvoApiClient alvoApiClient)
        {
            _logger = logger;
            _alvoApiClient = alvoApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Payroll()
        {
            return View();
        }

        public async Task<IActionResult> Download()
        {
            try
            {
                // Get the departments from the alvo.api
                var departments = await _alvoApiClient.GetDepartmentsAsync();

                // Serialize the translated departments to JSON
                var jsonSettings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new PortugueseNamingStrategy()
                    },
                    Converters = new List<JsonConverter>
                    {
                        new PortugueseNamingStrategyConverter(new CamelCaseNamingStrategy())
                    }
                };

                var json = JsonConvert.SerializeObject(departments, jsonSettings);


                // Create a file download response with the JSON content
                var fileContent = Encoding.UTF8.GetBytes(json);
                var contentType = "application/json";
                var fileName = "departments.json";
                return File(fileContent, contentType, fileName);
            }
            catch (Exception ex)
            {
                // Handle errors and log exceptions
                _logger.LogError(ex, "Erro ao buscar Registros");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}