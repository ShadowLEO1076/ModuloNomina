using System.Diagnostics.Contracts;
using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Castle.Components.DictionaryAdapter.Xml;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;


namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratosHistoricosControlador : ControllerBase
    {
        private readonly IContratosHistoricoServicio _servicio;

        public ContratosHistoricosControlador(IContratosHistoricoServicio servicio)
        {
            _servicio = servicio;
        }

        // GET: api/ContratosHistoricos/ListarContratoHistoricos
        [HttpGet("ListarContratoHistoricos")]
        public async Task<IActionResult> ListarTodos()
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

        // GET: api/ContratosHistoricos/BuscarHistoricoPorId/5
        [HttpGet("BuscarHistoricoPorId/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var historico = await _servicio.ObtenerPorIdAsync(id);
            if (historico == null)
                return NotFound();

            return Ok(historico);
        }

        // POST: api/ContratosHistoricos/InsertarContratosHistorico
        [HttpPost("InsertarContratosHistorico")]
        public async Task<IActionResult> Insertar([FromBody] ContratosHistorico contratohistorico)
        {
            if (contratohistorico == null)
            {
                return BadRequest("El contrato no puede ser nulo.");
            }
            try
            {
                await _servicio.AgregarAsync(contratohistorico);
                return CreatedAtAction(nameof(BuscarPorId), new { id = contratohistorico.IdHistorico }, contratohistorico);
               
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar el contrato: {ex.Message}");
            }
        }


        // DELETE: api/ContratosHistoricos/EliminarContratosHistorico/5
        [HttpDelete("EliminarContratosHistorico/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await _servicio.EliminarAsync(id);
            if (!eliminado)
                return NotFound();

            return Ok(new { mensaje = "Histórico eliminado correctamente (lógico o físico según tu implementación)." });
        }
    }
}
