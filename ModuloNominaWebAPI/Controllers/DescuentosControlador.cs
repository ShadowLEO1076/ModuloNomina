using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DescuentosControlador : ControllerBase
    {
        private readonly IDescuentosServicio _serv;

        public DescuentosControlador(IDescuentosServicio serv)
        {
            _serv = serv;
        }

        [HttpPost("ObtenerDescuentosEmpleadoPorCedulaMesAnio")]
        public async Task<IActionResult> ObtenerDescuentosEmpleadoPorCedulaMesAnio([FromBody] BusquedaDTO busqueda)
        {
            try
            {
                BusquedaDTO bus = busqueda;

                var busqServ = await _serv.ObtenerDescuentosEmpleadoPorCedulaMesAnio(bus);
                return Ok(busqServ);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - DescuentosControlador: {ex.Message}");
            }
        }

        [HttpPost("AgregarAsyn")]
        public async Task<IActionResult> AgregarAsync([FromBody] Descuentos descuentos)
        {
            try
            {
                await _serv.AgregarAsync(descuentos);
                return Ok(descuentos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - DescuentosControlador: {ex.Message}");
            }
        }
        [HttpGet("ObtenerTodos")]
        public async Task<IActionResult> ObtenerTodosAsync()
        {
            try
            {
                var busq = await _serv.ObtenerTodosAsync();
                return Ok(busq);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - BonificacionesControlador : {ex.Message}");
            }
        }
        /*
        [HttpPut("ActualizarAsyn")]
        public async Task<IActionResult> ActualizarAsync([FromBody] Descuentos descuento)
        {
            try
            {

            }
            catch
            {
                return StatusCode(500, $"Error - BnificacionesControlador")
            }

        }*/
    }
}
