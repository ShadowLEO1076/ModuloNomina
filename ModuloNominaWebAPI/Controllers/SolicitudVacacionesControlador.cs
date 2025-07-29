using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitudVacacionesControlador : ControllerBase
    {

        private ISolicitudVacacionesServicio _servicio;

        public SolicitudVacacionesControlador(ISolicitudVacacionesServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("ListarSolicitudVacaciones")]
        public async Task<IActionResult> ListarSolicitudVacaciones()
        {
            try
            {
                var solicitudes = await _servicio.ObtenerTodosAsync();
                return Ok(solicitudes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar las solicitudes: {ex.Message}");
            }
        }
        // eliminar 



        [HttpGet("BuscarPorId/{id}")] //-> Si ponemos un prefijo como SolicitudVacaciones/{id} no funciona
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var solicitud = await _servicio.ObtenerPorIdAsync(id);
                if (solicitud == null)
                {
                    return NotFound($"Solicitud con ID {id} no encontrada.");
                }
                return Ok(solicitud);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar la solicitud: {ex.Message}");
            }
        }


        [HttpPost("InsertarSolicitudVacaciones")]
        public async Task<IActionResult> InsertarSolicitudVacaciones([FromBody] SolicitudVacaciones solicitud)
        {
            if (solicitud == null)
            {
                return BadRequest("La solicitud de vacaciones no puede ser nula.");
            }
            try
            {
                await _servicio.AgregarAsync(solicitud);
                return CreatedAtAction(nameof(BuscarPorId), new { id = solicitud.IdSolicitud }, solicitud);
                return Ok(solicitud);


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al agregar la solicitud de vacaciones: {ex.Message}");
            }
        }


        [HttpPut("ActualizarSolicitudVacaciones")]
        public async Task<IActionResult> ActualizarSolicitudVacaciones([FromBody] SolicitudVacaciones solicitud)
        {
            if (solicitud == null)
            {
                return BadRequest("La solicitud de vacaciones no puede ser nula.");

            }
            try
            {
                await _servicio.ActualizarAsync(solicitud);
                return Ok(solicitud);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la solicitud de vacaciones: {ex.Message}");
            }
        }

        [HttpGet("ObtenerResumenSolicitudes")]
        public async Task<IActionResult> ObtenerResumenSolicitudes()
        {
            try
            {
                var solicitudesa = await _servicio.ObtenerResumenSolicitudesAsync();
                return Ok(solicitudesa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las solicitudes: {ex.Message}");
            }


        }
        [HttpDelete("EliminarSolicitudVacaciones/{id}")]
        public async Task<IActionResult> EliminarSolicitudVacaciones(int id)
        {
            try
            {
                await _servicio.EliminarAsync(id);
                return Ok($"Solicitud con ID {id} eliminada correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la solicitud: {ex.Message}");
            }
        }
        [HttpGet("ObtenerSolicitudesPorEstado/{estado}")]
        public async Task<IActionResult> ObtenerSolicitudesPorEstado(string estado)
        {
            try
            {
                var solicitudes = await _servicio.ObtenerSolicitudesPorEstadoAsync(estado);
                return Ok(solicitudes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las solicitudes por estado: {ex.Message}");
            }
        }
    }
}
