using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;
using System.ServiceModel;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InasistenciasControlador : ControllerBase
    {
        private readonly IInasistenciasServicio _serv;

        public InasistenciasControlador(IInasistenciasServicio serv)
        {
            _serv = serv;
        }

        [HttpPost("BuscarPorIdYFechaAsync")]
        public async Task<IActionResult> BuscarPorIdYFechaAsync([FromBody] VerificarAsisInasisDTO dato)
        {
            try
            {
                var busq = await _serv.BuscarPorIdYFecha(dato);
                return Ok(busq);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"AsistenciaControlador : {ex.Message}");
            }
        }

        [HttpGet("ObtenerTodasActivasInasistenciasFormDTO")]
        public async Task<IActionResult> ObtenerTodasActivasInasistenciasFormDTO()
        {
            try
            {
                var busq = await _serv.ObtenerTodasActivasInasistenciasFormDTO();
                return Ok(busq);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - InasistenciasControlador : {ex.Message}");
            }
        }

        [HttpPost("ObtenerInasistenciasPorCedulaMesAnio")]
        public async Task<IActionResult> ObtenerInasistenciasPorCedulaMesAnio([FromBody] BusquedaDTO busquedaDTO)
        { 
            try 
            {
                BusquedaDTO dto = busquedaDTO;

                var busq = await _serv.ObtenerInasistenciasPorCedulaMesAnio(dto);
                return Ok(busq);
            }
            catch(Exception ex) 
            {
                return StatusCode(500, $"Error - InasistenciasControlador : {ex.Message}");
            }
        }

        [HttpGet("BuscarPorCedulaAsync/{cedula}")]
        public async Task<IActionResult> BuscarPorCedulaAsync(string cedula)
        {
            try 
            {
                var busq = await _serv.BuscarPorCedulaAsync(cedula);
                return Ok(busq);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - InasistenciasControlador : {ex.Message}");
            }
        }
        [HttpGet("ObtenerTodosAsync")]
        public async Task<IActionResult> BuscarTodosAsync()
        {
            try
            {
                var busq = await _serv.ObtenerTodosAsync();
                return Ok(busq);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - InasistenciasControlador : {ex.Message}");
            }
        }
        [HttpPost("AgregarAsync")]
        public async Task<IActionResult> AgregarAsync([FromBody] Inasistencias inasistencia)
        {
            try 
            {
                await _serv.AgregarAsync(inasistencia);
                return Ok($"Se añadió el dato {inasistencia} correctaemnte.");
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Error - InasistenciasControlador : {ex.Message}");
            }
        }
        [HttpPut("ActualizarAsync")]
        public async Task<IActionResult> ActualizarAsync([FromBody] Inasistencias inasistencia)
        {
            try
            {
                await _serv.ActualizarAsync(inasistencia);
                return Ok($"Se actualizó el dato {inasistencia} correctaemnte.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - InasistenciasControlador : {ex.Message}");
            }
        }
        [HttpDelete("EliminarAsync/{id}")]
        public async Task<IActionResult> EliminarAsync(int id) 
        {
            try
            {
                var busq = _serv.ObtenerPorIdAsync(id);
                await _serv.EliminarAsync(id);
                return Ok($"Se eliminó la inasistencia con {id} con éxito.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - InasistenciasControlador : {ex.Message}");
            }
        }
        [HttpPost("ObtenerInasistenciasPorMesAnio")]
        public async Task<IActionResult> ObtenerInasistenciasPorMesAnio([FromBody] BusquedaDTO busquedaDTO)
        {
            try
            {
                var resultado = await _serv.ObtenerInasistenciasPorMesAnio(busquedaDTO);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - InasistenciasControlador : {ex.Message}");
            }
        }


    }
}
