using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.AccesoDatos;
namespace Dominio.Modelos.Abstracciones
{
    public interface IRepositorio<T> where T : class
    {
        Task<T> ObtenerPorIdAsync(int id);
        Task<IEnumerable<T>> ObtenerTodosAsync();
        Task AgregarAsync(T entidad);
        Task ActualizarAsync(T entidad);
        Task EliminarAsync(int id);
        Task<bool> ExisteAsync(int id); //opcional, si se necesita verificar la existencia de una entidad por ID
     
    }
}
