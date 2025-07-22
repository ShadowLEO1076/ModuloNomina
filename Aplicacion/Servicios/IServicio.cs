using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.AccesoDatos;


namespace Aplicacion.Servicios
{
    [ServiceContract]
    public interface IServicio<T>  where T : class // generico para servicios que manejan entidades de tipo T
    {
        [OperationContract]
        Task<T> ObtenerPorIdAsync(int id);
        [OperationContract]
        Task<IEnumerable<T>> ObtenerTodosAsync();
        [OperationContract]
        Task AgregarAsync(T entidad);
        [OperationContract]
        Task ActualizarAsync(T entidad);
        [OperationContract]
        Task<bool> EliminarAsync(int id);



    }

}
