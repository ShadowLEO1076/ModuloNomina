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
    public interface ISolicitudVacacionesServicio:IServicio<SolicitudVacaciones>
    {
        [OperationContract]
        Task<List<SolicitudVacacionDTO>> ObtenerResumenSolicitudesAsync();
        [OperationContract]
        Task<List<SolicitudVacacionDTO>> ObtenerSolicitudesPorEstadoAsync(string estado);
    }
}
