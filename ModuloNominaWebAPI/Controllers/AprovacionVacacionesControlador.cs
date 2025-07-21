using Aplicacion.Servicios;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AprovacionVacacionesControlador : ControllerBase
    {
        private IAprobacionVacacionesServicio _servicio;

        public AprovacionVacacionesControlador(IAprobacionVacacionesServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        [Route("ResumenDiasAprovadosDiasUsados/{cedula}")]
        public async Task<IActionResult> ResumenDiasAprovadosDiasUsados(string cedula)
        {
            try
            {
                var resumen = await _servicio.ResumenDiasAprovadosDiasUsadosAsync(cedula);
                if (resumen == null || !resumen.Any())
                {
                    return NotFound($"No se encontraron aprobaciones de vacaciones para la cédula {cedula}.");
                }
                return Ok(resumen);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el resumen de días aprobados y usados: {ex.Message}");
            }

        }
        [HttpGet("ListarAprobacionesVacaciones")]
        public async Task<IActionResult> ListarAprobacionesVacaciones()
        {
            try
            {
                var aprobaciones = await _servicio.ObtenerTodosAsync();
                return Ok(aprobaciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar las aprobaciones: {ex.Message}");
            }


        }
        [HttpGet("BuscarAprobacionPorId/{id}")]
        public async Task<IActionResult> BuscarAprobacionPorId(int id)
        {
            try
            {
                var aprobacion = await _servicio.ObtenerPorIdAsync(id);
                if (aprobacion == null)
                {
                    return NotFound($"Aprobación de vacaciones con ID {id} no encontrada.");
                }
                return Ok(aprobacion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar la aprobación: {ex.Message}");
            }

        }
        [HttpPost("InsertarAprobacionVacaciones")]
        public async Task<IActionResult> InsertarAprobacionVacaciones([FromBody] AprobacionVacaciones aprobacion)
        {
            if (aprobacion == null)
            {
                return BadRequest("La aprobación de vacaciones no puede ser nula.");
            }
            try
            {
                await _servicio.AgregarAsync(aprobacion);
                return CreatedAtAction(nameof(BuscarAprobacionPorId), new { id = aprobacion.IdAprobacion }, aprobacion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar la aprobación: {ex.Message}");
            }

        }
        [HttpPut("ActualizarAprobacionVacaciones/{id}")]
        public async Task<IActionResult> ActualizarAprobacionVacaciones(int id, [FromBody] AprobacionVacaciones aprobacion)
        {
            if (aprobacion == null)
            {
                return BadRequest("La aprobación de vacaciones no puede ser nula.");
            }
            if (id != aprobacion.IdAprobacion)
            {
                return BadRequest("El ID de la aprobación no coincide con el ID proporcionado en la URL.");
            }
            try
            {
                await _servicio.ActualizarAsync(aprobacion);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la aprobación: {ex.Message}");
            }

        }
        [HttpDelete("EliminarAprobacionVacaciones/{id}")]
        public async Task<IActionResult> EliminarAprobacionVacaciones(int id)
        {
            try
            {
                var aprobacion = await _servicio.ObtenerPorIdAsync(id);
                if (aprobacion == null)
                {
                    return NotFound($"Aprobación de vacaciones con ID {id} no encontrada.");
                }
                await _servicio.EliminarAsync(id);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la aprobación: {ex.Message}");
            }

        }
       
    }
}
    
