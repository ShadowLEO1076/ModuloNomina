using Aplicacion.DTO.DTOs;
using Infraestructura.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos.Abstracciones
{
    public interface IInasistenciasRepo: IRepositorio<Inasistencias>
    {
        Task<List<InasistenciasEmpleadoDTO>> ObtenerInasistenciasPorCedulaMesAnio(BusquedaDTO busquedaDTO);
        Task<IEnumerable<Inasistencias>> BuscarPorCedulaAsync(string cedula);

        Task<IEnumerable<InasistenciasFormDTO>> ObtenerTodasActivasInasistenciasFormDTO();

        Task<Inasistencias> BuscarPorIdYFecha(VerificarAsisInasisDTO dato);

        Task<List<InasistenciasEmpleadoDTO>> ObtenerInasistenciasPorMesAnio(BusquedaDTO busquedaDTO);
    }
}
