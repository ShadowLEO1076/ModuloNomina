using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsistenciasControlador : ControllerBase
    {
        private readonly IAsistenciasServicio _serv;
        public AsistenciasControlador(IAsistenciasServicio serv)
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

        [HttpGet("ObtenerTodasActivasAsistenciasFormDTO")]
        public async Task<IActionResult> ObtenerTodasActivasAsistenciasFormDTO()
        {
            try
            {
                var busq = await _serv.ObtenerTodasActivasAsistenciasFormDTO();
                return Ok(busq);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - AsistenciasControlador : {ex.Message}");
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
                return StatusCode(500, $"Error - AsistenciasControlador : {ex.Message}");
            }
        }
    
        [HttpPost("ObtenerAsistenciasEmpleadoPorCedulaMesAnio")]
        public async Task<IActionResult> ObtenerAsistenciasEmpleadoPorCedulaMesAnio([FromBody] BusquedaDTO busquedaDTO)
        {
            try
            {
                var dto = new BusquedaDTO
                {
                   // CedulaEmpleado = busquedaDTO.CedulaEmpleado,
                    anio = busquedaDTO.anio,
                    mes = busquedaDTO.mes
                };
                
                var busq = await _serv.ObtenerAsistenciasPorCedulaMesAnio(dto);

                return Ok(busq);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - AsistenciasControlador : {ex.Message}");
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
                return StatusCode(500, $"Error - AsistenciasControlador : {ex.Message}");

            }
        }

        [HttpPost("AgregarAsync")]
        public async Task<IActionResult> AgregarAsync([FromBody] Asistencias asistencia)
        {

            try
            {
                await _serv.AgregarAsync(asistencia);
                return Ok(asistencia);
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
                return Ok(asistencia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - AsistenciasControlador : {ex.Message}");

            }
        }

        [HttpDelete("EliminarAsync/{id}")]
        public async Task<IActionResult> EliminarAsync(int id)
        {
            try
            {
                var busq = await _serv.ObtenerPorIdAsync(id);

                if (busq == null)
                {
                    return StatusCode(501, $"No se encontró el elemento que se desea eliminar.");
                }

                await _serv.EliminarAsync(id);
                return Ok($"Asistencia con {id} eliminada correctamente.");
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Error - AsistenciasControlador : {ex.Message}");
            }
        }
    }
}
