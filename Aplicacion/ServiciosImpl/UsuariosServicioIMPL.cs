using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Dominio.Modelos.Abstracciones;
using Infraestructura.AccesoDatos;
using Infraestructura.AccesoDatos.Repositorio;

namespace Aplicacion.ServiciosImpl
{
    public class UsuariosServicioIMPL : IUsuariosServicio
    {
        private readonly IUsuariosRepo _repo;

        public UsuariosServicioIMPL(IUsuariosRepo repo) // Inyección de dependencia directa
        {
            _repo = repo;
        }

        public async Task<UsuarioRespuestaDTO> LoginAsync(LoginDTO loginDto)
        {
            byte[] hash = HashPassword(loginDto.Contraseña);
            var usuario = await _repo.ObtenerPorCedulaYContraseñaAsync(loginDto.Cedula, hash);

            return usuario == null
                ? null
                : new UsuarioRespuestaDTO
                {
                    Cedula = usuario.Cedula,
                    Rol = usuario.Rol,
                    NombreCompleto = usuario.Nombre
                };
        }

        private static byte[] HashPassword(string password)
        {
            using var sha = SHA256.Create();
            return sha.ComputeHash(Encoding.UTF8.GetBytes(password)); // Hash directo sin Base64
        }
    }
}