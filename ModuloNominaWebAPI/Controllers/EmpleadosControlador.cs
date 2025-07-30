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

        [HttpGet("VerificarCorreoElectronico/{correo}")]
        public async Task<IActionResult> VerificarCorreoElectronico(string correo)
        {
            try {

                bool existe = await _serv.VerificarCorreoElectronico(correo);
               
                return Ok(existe);
            }
            catch(Exception ex) 
            {
                return StatusCode(500, $"Error - EmpleadosControlador : no se puede verificar el correo. {ex.Message}");
            }        
        }
        [HttpGet("ObtenerTodosInactivosAsync")]
        public async Task<IActionResult> ObtenerTodosInactivosAsync()
        {
            try
            {
                var resultado = await _serv.ObtenerTodosInactivosAsync();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - EmpleadosControlador : no se pudo listar los elementos. {ex.Message}");
            }
        }

        [HttpGet("ObtenerTodosActivosAsync")]
        public async Task<IActionResult> ObtenerTodosActivosAsyinc()
        {
            try
            {
                var resultado = await _serv.ObtenerTodosActivosAsync();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - EmpleadosControlador : no se pudo listar los elementos. {ex.Message}");
            }
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
                return Ok(empleado);
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

        [HttpGet("ObtenerEmpleadoDTOPorCedula/{cedula}")]
        public async Task<IActionResult> ObtenerEmpleadoDTOPorCedula(string cedula)
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
                Empleados emple = empleado;
                await _serv.ActualizarAsync(emple);
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
     [HttpGet("ObtenerEmpleadoPorCedula/{cedula}")]
        public async Task<IActionResult> ObtenerEmpleadoorCedula(string cedula)
        {
            try
            {
                var resultado = await _serv.ObtenerEmpleadoPorCedulaAsync(cedula);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error - EmpleadosControlador : no se pudo listar los elementos. {ex.Message}");
            }
        }
    }
}
