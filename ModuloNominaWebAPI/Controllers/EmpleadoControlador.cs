using Aplicacion.Servicios;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace ModuloNominaWebAPI.Controllers
{
//   [ApiController] -> Se usar EmpledosControlador
//   [Route("api/[controller]")]
    public class EmpleadoControlador : ControllerBase
    {
        private IEmpleadosServicio _servicio;

        public EmpleadoControlador(IEmpleadosServicio servicio)
        {
            _servicio = servicio;
        }
        [HttpGet("ListarEmpleados")]
        public async Task<IActionResult> ListarEmpleados()
        {
            try
            {
                var empleados = await _servicio.ObtenerTodosAsync();
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar los empleados: {ex.Message}");
            }
        }
        [HttpGet("BuscarPorId/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var empleado = await _servicio.ObtenerPorIdAsync(id);
                if (empleado == null)
                {
                    return NotFound($"Empleado con ID {id} no encontrado.");
                }
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar el empleado: {ex.Message}");
            }
        }
        [HttpPost("InsertarEmpleado")]
        public async Task<IActionResult> InsertarEmpleado([FromBody] Empleados empleado)
        {
          
            try
            {
               await _servicio.AgregarAsync(empleado);
                return CreatedAtAction(nameof(BuscarPorId), new { id = empleado.IdEmpleado }, empleado);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar el empleado: {ex.Message}");
            }



        }
        [HttpPut("ActualizarEmpleado/{id}")]
        public async Task<IActionResult> ActualizarEmpleado(int id, [FromBody] Empleados empleado)
        {
            
            try
            {
                await _servicio.ActualizarAsync(empleado);
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el empleado: {ex.Message}");
            }
        }
        [HttpDelete("EliminarEmpleado/{id}")]
        public async Task<IActionResult> EliminarEmpleado(int id)
        {
            try
            {
                await _servicio.EliminarAsync(id);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el empleado: {ex.Message}");
            }
        }
    }
}