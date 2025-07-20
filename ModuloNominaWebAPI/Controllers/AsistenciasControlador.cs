using Aplicacion.Servicios;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/ [controller]")]
    public class AsistenciasControlador : ControllerBase
    {
        private readonly IAsistenciasServicio _serv;
        public AsistenciasControlador(IAsistenciasServicio serv) 
        {
            _serv = serv;
        }

        [HttpGet("ObtenerTodosAsync")]
        public async Task<IActionResult> ObtenerTodosAsync()
        {
            try
            {
                var busq = await _serv.ObtenerTodosAsync();
                return Ok(busq);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - AsistenciasControlador : {ex.Message}");

            }
        }

        [HttpPost("AgregarAsync")]
        public async Task<IActionResult> AgregarAsync([FromBody] Asistencias asistencia)
        {

            try
            {
                await _serv.AgregarAsync(asistencia);
                return Ok($"Se añadió correctamente las asistencia.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - AsistenciasControlador : {ex.Message}");

            }
        }
        [HttpPut("ActualizarAsync")]
        public async Task<IActionResult> ActualizarAsync([FromBody] Asistencias asistencia)
        {

            try
            {
                await _serv.ActualizarAsync(asistencia);
                return Ok($"Se actualizó correctamente la asistencia.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - AsistenciasControlador : {ex.Message}");

            }
        }

    }
}
