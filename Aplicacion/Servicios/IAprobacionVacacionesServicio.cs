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
    public interface IAprobacionVacacionesServicio :IServicio<AprobacionVacaciones>
    {
        [OperationContract]
        Task<IEnumerable<VacacionesAprovadasGestionDTO>> ResumenDiasAprovadosDiasUsadosAsync(string cedula);
        // Método para buscar aprobaciones de vacaciones por empleado usando su cédula
        // LO MAS LOGICO SERIA BUSCAR POR CÉDULA, YA QUE LA FECHA DE APROBACIÓN PUEDE VARIAR
    }
}
