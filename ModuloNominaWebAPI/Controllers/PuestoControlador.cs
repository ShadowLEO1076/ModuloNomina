using Aplicacion.Servicios;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuestoControlador : ControllerBase
    {
        private IPuestosServicio _servicio;

        public PuestoControlador(IPuestosServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("BuscarPuestoPorNombre/{nombre}")] 
        public async Task<IActionResult> BuscarPuestoPorNombre(string nombre)
        {
            try
            {
                var puestos = await _servicio.BuscarPorPuestoAsync(nombre);
                if (puestos == null || !puestos.Any())
                {
                    return NotFound($"No se encontraron puestos con el nombre {nombre}.");
                }
                return Ok(puestos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar puestos por nombre: {ex.Message}");
            }
        }
        [HttpGet("ListarPuestos")]
        public async Task<IActionResult> ListarPuestos()
        {
            try
            {
                var puestos = await _servicio.ObtenerTodosAsync();
                return Ok(puestos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar los puestos: {ex.Message}");
            }
        }
        [HttpGet("BuscarPuestoPorId/{id}")]
        public async Task<IActionResult> BuscarPuestoPorId(int id)
        {
            try
            {
                var puesto = await _servicio.ObtenerPorIdAsync(id);
                if (puesto == null)
                {
                    return NotFound($"Puesto con ID {id} no encontrado.");
                }
                return Ok(puesto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar el puesto: {ex.Message}");
            }
        }
        [HttpPost("InsertarPuesto")]
        public async Task<IActionResult> InsertarPuesto([FromBody] Puestos puesto)
        {
            if (puesto == null)
            {
                return BadRequest("El puesto no puede ser nulo.");
            }
            try
            {
                await _servicio.AgregarAsync(puesto);
                return CreatedAtAction(nameof(BuscarPuestoPorId), new { id = puesto.IdPuesto }, puesto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar el puesto: {ex.Message}");
            }
        }
        [HttpPut("ActualizarPuesto/{id}")]
        public async Task<IActionResult> ActualizarPuesto(int id, [FromBody] Puestos puesto)
        {
            if (puesto == null || id != puesto.IdPuesto)
            {
                return BadRequest("El puesto no puede ser nulo y el ID debe coincidir.");
            }
            try
            {
                var puestoExistente = await _servicio.ObtenerPorIdAsync(id);
                if (puestoExistente == null)
                {
                    return NotFound($"Puesto con ID {id} no encontrado.");
                }
                await _servicio.ActualizarAsync(puesto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el puesto: {ex.Message}");
            }
        }
        [HttpDelete("EliminarPuesto/{id}")] //para eliminar un puesto por ID 
        public async Task<IActionResult> EliminarPuesto(int id)
        {
            try
            {
                var puestoExistente = await _servicio.ObtenerPorIdAsync(id);
                if (puestoExistente == null)
                {
                    return NotFound($"Puesto con ID {id} no encontrado.");
                }
                await _servicio.EliminarAsync(id);
                return Ok($"Puesto con ID {id} eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el puesto: {ex.Message}");
            }

        }

    }
}