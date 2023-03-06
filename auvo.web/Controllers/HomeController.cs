using auvo.web.Models;
using auvo.web.Services;
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
     
                var departments = await _alvoApiClient.GetDepartmentsAsync();

                var json = JsonConvert.SerializeObject(departments);

                var fileContent = Encoding.UTF8.GetBytes(json);
                var contentType = "application/json";
                var fileName = "departments.json";
                return File(fileContent, contentType, fileName);
            }
            catch (Exception ex)
            {
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