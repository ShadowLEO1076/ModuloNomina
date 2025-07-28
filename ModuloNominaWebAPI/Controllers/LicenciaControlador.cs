using Aplicacion.Servicios;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Security.Permissions;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LicenciaControlador : ControllerBase
    {
        private readonly ILicenciasServicio _serv;

        public LicenciaControlador(ILicenciasServicio serv)
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
                return StatusCode(500, $"Error - LicenciaController : {ex.Message}");
            }
        }

        [HttpPost("InsertarAsync")]
        public async Task<IActionResult> InsertarAsync([FromBody] Licencias licencia)
        {
            try
            {
                await _serv.AgregarAsync(licencia);

                return Ok(licencia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - LicenciaController : {ex.Message}");
            }
        }

        [HttpPut("ActualizarAsync")]
        public async Task<IActionResult> ActualizarAsync([FromBody] Licencias licencia)
        {
            try
            {
                await _serv.AgregarAsync(licencia);

                return Ok(licencia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - LicenciaController : {ex.Message}");
            }
        }

        [HttpDelete("EliminarAsync/{id}")]
        public async Task<IActionResult> EliminarAsync(int id)
        {
            try
            {
                var elim = await _serv.EliminarAsync(id);

                return Ok(elim);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - LicenciaController : {ex.Message}");
            }
        }
    }
}
