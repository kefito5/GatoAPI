using GatoAPI.Modelos;
using GatoAPI.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace GatoAPI.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialPartidaController : ControllerBase
    {
        private readonly HistorialPartidaRepository _repository;

        public HistorialPartidaController(HistorialPartidaRepository repository)
        {
            _repository = repository;
        }

        // CREATE / POST
        [HttpPost]
        public async Task<IActionResult> CrearHistorial([FromBody] HistorialPartidas historial)
        {
            await _repository.CrearHistorial(historial);
            return Ok(new
            {
                message = "Historial registrado de forma exitosa!"
            });
        }

        // READ / GET
        [HttpGet]
        public async Task<ActionResult<List<HistorialPartidas>>> LeerTodoHistorial()
        {
            return await _repository.LeerHistorial();
        }
    }
}