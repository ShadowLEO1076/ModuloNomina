using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Infraestructura.AccesoDatos;
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
                return StatusCode(500, $"Error - NominasControlador : {ex.Message}");
            }
        }
        [HttpPost("InsertarAsync")]
        public async Task<IActionResult> InsertarAsync([FromBody] Nominas nomina) 
        {
            try 
            {
                await _serv.AgregarAsync(nomina);
                return Ok(nomina);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Error - NominasControlador : {ex.Message}");
            }
        } 

        [HttpPut("ActualizarAsync")]
        public async Task<IActionResult> ActualizarAsync([FromBody] Nominas nomina) 
        {
            try
            {
                await _serv.ActualizarAsync(nomina);
                return Ok("Se actualizó correctamente la nomina.");
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Error - NominasControlador : {ex.Message}");
            }
        }
        [HttpDelete("EliminarAsync")]
        public async Task<IActionResult> EliminarAsync(int id)
        {
            try
            {
                var nomina = await  _serv.ObtenerPorIdAsync(id);
                await _serv.ActualizarAsync(nomina);
                return Ok("Se actualizó correctamente la nomina.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - NominasControlador : {ex.Message}");
            }
        }
    }
}
