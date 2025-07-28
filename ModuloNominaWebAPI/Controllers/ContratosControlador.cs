using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratosControlador : ControllerBase
    {

        private IContratosServicio _servicio;

        public ContratosControlador(IContratosServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("ListarContratos")]
        public async Task<IActionResult> ListarContratos()
        {
            try
            {
                var contratos = await _servicio.ObtenerTodosAsync();
                return Ok(contratos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar los contratos: {ex.Message}");
            }
        }




        [HttpGet("BuscarPorId/{id}")] //-> Si ponemos un prefijo como SolicitudVacaciones/{id} no funciona
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var contrato = await _servicio.ObtenerPorIdAsync(id);
                if (contrato == null)
                {
                    return NotFound($"Contrato con ID {id} no encontrado.");
                }
                return Ok(contrato);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar el contrato: {ex.Message}");
            }
        }




        [HttpPost("InsertarContratos")]
        public async Task<IActionResult> InsertarContratos([FromBody] Contratos contrato)
        {
            if (contrato == null)
            {
                return BadRequest("El contrato no puede ser nulo.");
            }
            try
            {
                await _servicio.AgregarAsync(contrato);
                return CreatedAtAction(nameof(BuscarPorId), new { id = contrato.IdContrato }, contrato);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar el contrato: {ex.Message}");
            }
        }



        [HttpPut("ActualizarContratos")]
        public async Task<IActionResult> ActualizarContratos([FromBody] Contratos contrato)
        {
            if (contrato == null)
            {
                return BadRequest("El contrato no puede ser nulo.");
            }
            try
            {
                await _servicio.ActualizarAsync(contrato);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el contrato: {ex.Message}");
            }
        }



        [HttpDelete("EliminarContratos/{id}")]
        public async Task<IActionResult> EliminarContratos(int id)
        {
            try
            {
                await _servicio.EliminarAsync(id);
                return Ok($"contrato con ID {id} eliminada correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el contrato: {ex.Message}");
            }
        }



        [HttpGet("ObtenerContratosCompletos")]
        public async Task<IActionResult> ObtenerContratosCompletos()
        {
            try
            {
                var contratosCompletos = await _servicio.ObtenerContratosCompletosAsync();
                return Ok(contratosCompletos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los contratos completos: {ex.Message}");
            }
        }

        [HttpGet("ObtenerContratosPorFecha")]
        public async Task<IActionResult> ObtenerContratosPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                var contratos = await _servicio.BuscarPorFechaAsync(fechaInicio, fechaFin);
                return Ok(contratos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar contratos por fecha: {ex.Message}");
            }
        }

        [HttpGet("ObtenerContratosPorEmpleado")] // Ruta para obtener contratos por empleado por cedula
        public async Task<IActionResult> ObtenerContratosPorEmpleado(string cedula)
        {
            try
            {
                var contratos = await _servicio.ObtenerContratosPorEmpleadoAsync(cedula);
                return Ok(contratos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener contratos por empleado: {ex.Message}");
            }
        }

        /*[HttpGet("ObtnerContratosActivos")]
        public async Task<IActionResult> ObtenerContratosActivos([FromQuery] DateTime? fecha = null)
        {
            try
            {
                var fechaFiltro = fecha ?? DateTime.Today;
                var contratos = await _servicio.ObtenerContratosVigentesAsync(fechaFiltro);
                return Ok(contratos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener contratos Activos: {ex.Message}");
            }
        }*/
        [HttpPut("FinalizarContratosVencidos")]
        public async Task<IActionResult> FinalizarContratosVencidos()
        {
            try
            {
                var cantidad = await _servicio.FinalizarContratosVencidosAsync();
                return Ok(new { mensaje = $"Se actualizaron {cantidad} contratos a 'Finalizado'." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al finalizar contratos: {ex.Message}");
            }
        }
        [HttpPut("ActualizarContrato")]
        public async Task<IActionResult> ActualizarContrato([FromBody] ContratoDTO contrato)
        {
            try
            {
                await _servicio.ActualizarContratoAsync(contrato);
                return Ok("Contrato actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar contrato: {ex.Message}");
            }
        }


    }
}
