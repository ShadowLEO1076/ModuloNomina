using System.Linq;
using System.Threading.Tasks;
using Dominio.Modelos.Abstracciones;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class UsuariosRepositorioIMPL : RepositorioImpl<Usuarios>, IUsuariosRepo
    {
        private readonly NominaDBContext _context;

        public UsuariosRepositorioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuarios> ObtenerPorCedulaYContraseñaAsync(string cedula, byte[] contraseña)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Cedula == cedula && u.Contraseña.SequenceEqual(contraseña));

            return usuario; // Retorna null si no encuentra coincidencia
        }
    }
}