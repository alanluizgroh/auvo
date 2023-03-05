using auvo.api.Services;
using auvo.domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace auvo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly RepositoryPayrollService _repository;
        private readonly ILogger<PayrollController> _logger;

        public PayrollController(RepositoryPayrollService repository, ILogger<PayrollController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var departments = await _repository.GetAsync();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar Registros");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Department value)
        {
            try
            {
                await _repository.CreateAsync(value);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao inserir Registro");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
