using Aplicacion.Servicios;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratoTipoControlador : ControllerBase
    {
        private IContratosTipoServicio _servicio;

        public ContratoTipoControlador(IContratosTipoServicio servicio)
        {
            _servicio = servicio;
        }
        [HttpGet("ListarTiposContratos")]
        public async Task<IActionResult> ListarTiposContratos()
        {
            try
            {
                var tiposContratos = await _servicio.ObtenerTodosAsync();
                return Ok(tiposContratos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar los tipos de contratos: {ex.Message}");
            }
        }



        [HttpGet("BuscarPorId/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var tipoContrato = await _servicio.ObtenerPorIdAsync(id);
                if (tipoContrato == null)
                {
                    return NotFound($"Tipo de contrato con ID {id} no encontrado.");
                }
                return Ok(tipoContrato);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar el tipo de contrato: {ex.Message}");
            }
        }

        [HttpPost("InsertarTipoContrato")]
        public async Task<IActionResult> InsertarTipoContrato([FromBody] ContratosTipo tipoContrato)
        {
            if (tipoContrato == null)
            {
                return BadRequest("El tipo de contrato no puede ser nulo.");
            }
            try
            {
                await _servicio.AgregarAsync(tipoContrato);
                return CreatedAtAction(nameof(BuscarPorId), new { id = tipoContrato.IdTipo}, tipoContrato);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar el tipo de contrato: {ex.Message}");
            }
        }







        [HttpPut("ActualizarTipoContrato/{id}")]
        public async Task<IActionResult> ActualizarTipoContrato(int id, [FromBody] ContratosTipo tipoContrato)
        {
            if (tipoContrato == null || tipoContrato.IdTipo != id)
            {
                return BadRequest("Los datos del tipo de contrato son inválidos.");
            }
            try
            {
                await _servicio.ActualizarAsync(tipoContrato);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el tipo de contrato: {ex.Message}");
            }
        }

        [HttpDelete("EliminarTipoContrato/{id}")]
        public async Task<IActionResult> EliminarTipoCOntrato(int id)
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



    }
}