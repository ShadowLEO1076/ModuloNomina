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
    public interface IContratosServicio: IServicio<Contratos>
    {
        [OperationContract]
        Task<List<ContratoDTO>> ObtenerContratosCompletosAsync();
        [OperationContract]
        Task<List<ContratoDTO>> ObtenerContratosPorEmpleadoAsync(string cedula);
        [OperationContract]
        Task<IEnumerable<Contratos>> BuscarPorFechaAsync(DateTime fechaInicio, DateTime fechaFin);
        
        [OperationContract]
        Task<bool> ActualizarEstadoContratoAsync(int idContrato, string nuevoEstado);
    }
}
