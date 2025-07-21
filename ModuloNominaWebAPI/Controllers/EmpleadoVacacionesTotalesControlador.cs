using Aplicacion.Servicios;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoVacacionesTotalesControlador: ControllerBase
    {
        private IEmpleadosVacacionesTotalesServicio _servicio;

        public EmpleadoVacacionesTotalesControlador(IEmpleadosVacacionesTotalesServicio servicio)
        {
            _servicio = servicio;
        }
        [HttpPost("asignar-vacaciones")] // esto sirve para asignar las vacaciones anuales a los empleados pero no se usa en la aplicación
        // el método recibe un objeto de tipo AprobacionVacaciones, pero no se usa en la aplicación
        public async Task<IActionResult> AsignarVacaciones([FromBody] AprobacionVacaciones aprobacion)
        {
            try
            {
               
                var resumen = await _servicio.AsignarVacacionesAnualesAsync();
                return Ok(resumen);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al asignar las vacaciones: {ex.Message}");
            }
        }
        [HttpGet("resumen-vacaciones")]
        public async Task<IActionResult> ObtenerResumenVacaciones()
        {
            try
            {
                var resumen = await _servicio.ObtenerConEmpleadoAsync();
                return Ok(resumen);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el resumen de vacaciones: {ex.Message}");
            }
        }
        
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




        [HttpDelete("EliminarEmpleadoVacaciones/{id}")]
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






    }
}

