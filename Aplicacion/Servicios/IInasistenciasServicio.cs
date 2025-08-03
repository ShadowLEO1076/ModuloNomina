using Aplicacion.DTO.DTOs;
using Infraestructura.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace Aplicacion.Servicios
{
    [ServiceContract]
    public interface IInasistenciasServicio:IServicio<Inasistencias>
    {
        [OperationContract]
        Task<List<InasistenciasEmpleadoDTO>> ObtenerInasistenciasPorCedulaMesAnio(BusquedaDTO busquedaDTO);
        [OperationContract]
        Task<IEnumerable<Inasistencias>> BuscarPorCedulaAsync(string cedula);
        [OperationContract]
        Task<IEnumerable<InasistenciasFormDTO>> ObtenerTodasActivasInasistenciasFormDTO();

        [OperationContract]
        Task<Inasistencias> BuscarPorIdYFecha(VerificarAsisInasisDTO dato);
        [OperationContract]
        Task<List<InasistenciasEmpleadoDTO>> ObtenerInasistenciasPorMesAnio(BusquedaDTO busquedaDTO);
    }
}
