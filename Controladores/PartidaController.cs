using GatoAPI.Modelos;
using GatoAPI.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace GatoAPI.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidaController : ControllerBase
    {
        private readonly PartidaRepository _repository;

        public PartidaController(PartidaRepository repository)
        {
            _repository = repository;
        }

        // CREATE / POST
        [HttpPost]
        public async Task<IActionResult> CrearPartidas([FromBody] Partidas partida)
        {
            await _repository.CrearPartidas(partida);
            return Ok(new
            {
                message = "Partida creada de forma exitosa!"
            });
        }

        // READ / GET
        [HttpGet]
        public async Task<ActionResult<List<Partidas>>> LeerTodasPartidas()
        {
            return await _repository.LeerPartidas();
        }

        // UPDATE / PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPartida(int id, [FromBody] Partidas partida)
        {
            if (id != partida.idPartida)
            {
                return BadRequest();
            }
            else
            {
                await _repository.Actualizar(partida);
                return NoContent();
            }
        }

        // DELETE / DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPartida(int id)
        {
            await _repository.Eliminar(id);
            return NoContent();
        }
    }
}