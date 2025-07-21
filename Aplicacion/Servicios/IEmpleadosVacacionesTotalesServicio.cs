using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Infraestructura.AccesoDatos;

namespace Aplicacion.Servicios
{
    [ServiceContract]
    public interface IEmpleadosVacacionesTotalesServicio: IServicio<EmpleadosVacacionesTotales>
    {
      
        [OperationContract]
        Task<IEnumerable<EmpleadosVacacionesTotales>> ObtenerConEmpleadoAsync();
        [OperationContract]
        Task<List<VacacionesAsignadasDTO>> AsignarVacacionesAnualesAsync();
    }
}
