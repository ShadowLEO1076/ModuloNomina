using Aplicacion.Servicios;
using Castle.Components.DictionaryAdapter.Xml;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosControlador : ControllerBase
    {
        private IEmpleadosServicio _serv;

        public EmpleadosControlador(IEmpleadosServicio serv)
        {
            _serv = serv;
        }

        [HttpGet("ObtenerTodosAsync")]
        public async Task<IActionResult> ObtenerTodosAsync()
        {
            try
            {
                var resultado = await _serv.ObtenerTodosAsync();
                return Ok(resultado);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Error - EmpleadosControlador : no se pudo listar los elementos. {ex.Message}");
            }
        }

        [HttpPost("InsertarAsync")]
        public async Task<IActionResult> AgregarAsync([FromBody] Empleados empleado)
        {
            try
            {
                await _serv.AgregarAsync(empleado);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - EmpleadosControlador : no se pudo agregar el elemento. {ex.Message}");
            }
        }
        [HttpPut("ActualizarAsync")]
        public async Task<IActionResult> ActualizarAsync([FromBody] Empleados empleado)
        {
            try
            {   
                await _serv.ActualizarAsync(empleado);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - EmpleadosControlador : no se pudo actualizar los elemento. {ex.Message}");
            }
        }

        [HttpPost("ObtenerEmpleadoPorCedula/{cedula}")]
        public async Task<IActionResult> ObtenerEmpleadoPorCedula( string cedula)
        {
            try
            {
                var resultado = await _serv.ObtenerEmpleadoDTOPorCedulaAsync(cedula);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - EmpleadosControlador : no se pudo listar los elementos. {ex.Message}");
            }
        }
        [HttpPut("ActualizarEmpleado")]
        public async Task<IActionResult> ActualizarEmpleado([FromBody] Empleados empleado)
        {

            try
            {
                await _serv.ActualizarAsync(empleado);
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
                await _serv.EliminarAsync(id);
                return Ok("Empleado eliminado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el empleado: {ex.Message}");
            }
        }
    }
}
