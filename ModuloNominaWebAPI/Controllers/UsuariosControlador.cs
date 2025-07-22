using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ModuloNominaWebAPI.Controllers
{
    [ApiController]

    [Route("api/[controller]")] // ¡Prefijo "api/"!// Cambiado a "api/[controller]" para consistencia
    public class UsuariosControlador : ControllerBase
    {
        private readonly IUsuariosServicio _servicio;

        public UsuariosControlador(IUsuariosServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Cedula) || string.IsNullOrWhiteSpace(dto.Contraseña))
                return BadRequest("Debe ingresar cédula y contraseña.");

            var usuario = await _servicio.LoginAsync(dto);

            if (usuario == null)
                return Unauthorized("Cédula o contraseña incorrecta.");

            return Ok(usuario);
        }
    }
}