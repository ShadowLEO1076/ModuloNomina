using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BonificacionesControlador : ControllerBase
    {
        private readonly IBonificacionesServicio _serv;

        public BonificacionesControlador(IBonificacionesServicio serv)
        {
            _serv = serv;
        }

        [HttpGet("ObtenerTodasActivasBonificacionesFormDTO")]
        public async Task<IActionResult> ObtenerTodasActivasBonificacionesFormDTO()
        {
            try 
            {
                var busq = await _serv.ObtenerTodasActivasBonificacionesFormDTO();
                return Ok(busq);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - BonificaionesControlador : {ex.Message}");
            }
        }
        //se necesita hacerlo post para poder traer los datos. Pues la lógica es postear dto, recibir datos.
        [HttpPost("ObtenerBonificacionesPorCedulaMesYAnio")]
        public async Task<IActionResult> ObtenerBonificacionesPorCedulaMesYAnio([FromBody] BusquedaDTO datos)
        {
            try 
            {
                BusquedaDTO busq = new BusquedaDTO
                {
                    CedulaEmpleado = datos.CedulaEmpleado,
                    mes = datos.mes,
                    anio = datos.anio
                };

                var busqSer = await _serv.ObtenerBonificacionesPorCedulaMesYAnio(busq);
                return Ok(busqSer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - BonificacionesControlador : {ex.Message}");
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
                return StatusCode(500, $"Error - BonificacionesControlador : {ex.Message}");
            }
        }
        [HttpPost("AgregarAsync")]
        public async Task<IActionResult> AgregarAsync([FromBody] Bonificaciones boni) 
        {
            try
            {
                await _serv.AgregarAsync(boni);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - BonificacionesControlador : {ex.Message}");
            }
        }

        [HttpPut("ActualizarAsync")]
        public async Task<IActionResult> ActualizarAsync([FromBody] Bonificaciones boni)
        {
            try
            {
                await _serv.ActualizarAsync(boni);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - BonificacionesControlador : {ex.Message}");
            }
        }

        [HttpDelete("EliminarAsync/{id}")]
        public async Task<IActionResult> ElimnarAsync(int id)
        {
            try
            {
                await _serv.EliminarAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - BonificacionesControlador : {ex.Message}");
            }
        }
    }
}
