using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NominasControlador : ControllerBase
    {
        private readonly INominasServicio _serv;

        public NominasControlador(INominasServicio serv)
        {
            _serv = serv;
        }

        [HttpPost("InsertarNominaAuto")]
        public async Task<IActionResult> InsertarNominaAuto([FromBody] BusquedaDTO busqueda)
        {
            try
            {
                BusquedaDTO datos = busqueda;
                await _serv.IngresarNomionaAutomático(datos);

                return Ok(datos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - NominasControlador : {ex.Message}");
            }
        }
    }
}
