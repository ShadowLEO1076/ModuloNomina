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
    public interface IAsistenciasServicio : IServicio<Asistencias>
    {
        [OperationContract]
        //MÉTODO DE MATEO, si necesitan, copiar y reutilizar
        Task<List<AsistenciasEmpleadoDTO>> ObtenerAsistenciasPorCedulaMesAnio(NominasBusquedaDTO busquedaDTO);

        [OperationContract]
        public TimeSpan CalcularHorasTrabajadas(List<AsistenciasEmpleadoDTO> lista);

        [OperationContract]
        Task<List<AsistenciasEmpleadoDTO>> ObtenerAsistenciasPorCedulaMesAnio(BusquedaDTO busquedaDTO);

        [OperationContract]
        Task<IEnumerable<Asistencias>> BuscarPorCedulaAsync(string cedula);

        [OperationContract]
        //el  métodos bnusca el DTO de todos los empleados activos, asegurando así que no veamos datos no deseados.
        Task<IEnumerable<AsistenciasFormDTO>> ObtenerTodasActivasAsistenciasFormDTO();

        [OperationContract]
        Task<Asistencias> BuscarPorIdYFecha(VerificarAsisInasisDTO dato);
    }
}
