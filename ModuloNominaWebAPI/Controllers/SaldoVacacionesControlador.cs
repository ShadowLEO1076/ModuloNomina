using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaldoVacacionesControlador : ControllerBase
    {
        private ISaldoVacacionesServicio _servicio;
        public SaldoVacacionesControlador(ISaldoVacacionesServicio servicio)
        {
            _servicio = servicio;
        }
        [HttpGet("ListarSaldoVacaciones")]
        public async Task<IActionResult> ListarSaldoVacaciones()
        {
            try
            {
                var saldovacaciones = await _servicio.ObtenerTodosAsync();
                return Ok(saldovacaciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar las saldos: {ex.Message}");
            }
        }
        [HttpGet("BuscarSaldoPorId/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var saldovacaciones = await _servicio.ObtenerPorIdAsync(id);
                if (saldovacaciones == null)
                {
                    return NotFound($"saldo vacaciones con ID {id} no encontrada.");
                }
                return Ok(saldovacaciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar la saldo: {ex.Message}");
            }
        }
        [HttpPost("InsertarSaldoVacaciones")]
        public async Task<IActionResult> InsertarSolicitudVacaciones([FromBody] SaldoVacaciones saldo)
        {
            if (saldo == null)
            {
                return BadRequest("La saldo de vacaciones no puede ser nula.");
            }
            try
            {
                await _servicio.AgregarAsync(saldo);
                return CreatedAtAction(nameof(BuscarPorId), new { id = saldo.Id }, saldo);
                return Ok(saldo);


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al agregar el saldo de vacaciones: {ex.Message}");
            }
        }
        [HttpPut("ActualizarSaldoVacaciones/{id}")]
        public async Task<IActionResult> ActualizarSolicitudVacaciones([FromBody] SaldoVacaciones saldo)
        {
            if (saldo == null)
            {
                return BadRequest("el saldo de vacaciones no puede ser nula.");

            }
            try
            {
                await _servicio.ActualizarAsync(saldo);
                return Ok(saldo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el saldo de vacaciones: {ex.Message}");
            }
        }
        [HttpDelete("EliminarSaldoVacaciones/{id}")]
        public async Task<IActionResult> EliminarAprobacionVacaciones(int id)
        {
            try
            {
                var saldovacaciones = await _servicio.ObtenerPorIdAsync(id);
                if (saldovacaciones == null)
                {
                    return NotFound($"saldo de vacaciones con ID {id} no encontrada.");
                }
                await _servicio.EliminarAsync(id);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el saldo de vacaciones: {ex.Message}");
            }

        }
        /*[HttpGet("BuscarSaldoPorIdEmpleado/{id }")]
        public async Task<IActionResult> ObtenerPorEmpleadoIdAsync(int id)
        {
            try
            {
                var saldovacaciones = await _servicio.ObtenerPorIdAsync(id);
                if (saldovacaciones == null)
                {
                    return NotFound($"saldo vacaciones con ID {id} no encontrada.");
                }
                return Ok(saldovacaciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar la saldo: {ex.Message}");
            }
        }*/
        [HttpPost("AsignarDiasVacacionesAutomaticamente")]
        public async Task<IActionResult> AsignarDiasVacacionesAutomaticamenteAsync()
        {
            try
            {
                // Este servicio debe encargarse de:
                // - Verificar cada empleado si ya tiene asignación para el año actual.
                // - Si no la tiene, asignar 15 días, actualizar fecha y año.
                await _servicio.AsignarDiasVacacionesAutomaticamenteAsync();

                return Ok(new { mensaje = "Días de vacaciones asignados exitosamente." });
            }
            catch (Exception ex)
            {
                // Log opcional aquí si tienes logger
                return StatusCode(500, new { error = "Error al asignar vacaciones: " + ex.Message });
            }
        }
        [HttpGet("BuscarSaldoPorIdEmpleado/{id}")]
        public async Task<IActionResult> BuscarSaldoPorEmpleado(int id)
        {
            try
            {
                var resultado = await _servicio.BuscarPorEmpleadoIdAsync(id);

                // Devuelve un objeto con estructura consistente incluso cuando no hay saldo
                return Ok(resultado ?? new SaldoVacaciones
                {
                    IdEmpleado = id,
                    DiasAcumulados = 0,
                    DiasUsadosAnioActual = 0
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "Error interno al buscar saldo de vacaciones",
                    Detail = ex.Message
                });
            }
        }









    }
}
