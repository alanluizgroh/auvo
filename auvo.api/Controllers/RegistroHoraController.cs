using auvo.api.Services;
using auvo.model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace auvo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroHoraController : ControllerBase
    {
        private readonly RepositoryRegistroHoraVOService _repository;
        private readonly ILogger<RegistroHoraController> _logger;

        public RegistroHoraController(RepositoryRegistroHoraVOService repository, ILogger<RegistroHoraController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Payroll value)
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
