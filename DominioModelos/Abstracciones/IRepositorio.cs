using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.AccesoDatos;
namespace Dominio.Modelos.Abstracciones
{
    /* This code snippet defines a generic interface in C# named `IRepositorio<T>`. The interface
    includes several asynchronous methods that can be implemented by classes that inherit from it.
    Here's a breakdown of the methods: */
    // lo de arriba pero en espñol la traduccion abajo:
    // Este fragmento de código define una interfaz genérica en C# llamada `IRepositorio<T>`. La interfaz
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
