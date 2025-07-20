using Aplicacion.Servicios;
using Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuestoControlador : ControllerBase
    {
        private IPuestosServicio _servicio;

        public PuestoControlador(IPuestosServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("BuscarPuestoPorNombre/{nombre}")] 
        public async Task<IActionResult> BuscarPuestoPorNombre(string nombre)
        {
            try
            {
                var puestos = await _servicio.BuscarPorPuestoAsync(nombre);
                if (puestos == null || !puestos.Any())
                {
                    return NotFound($"No se encontraron puestos con el nombre {nombre}.");
                }
                return Ok(puestos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar puestos por nombre: {ex.Message}");
            }
        }

    }
}