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
        Task<List<AsistenciasEmpleadoDTO>> ObtenerInasistenciasPorCedulaMesAnio(BusquedaDTO busquedaDTO);
        Task<IEnumerable<Asistencias>> BuscarPorCedulaAsync(string cedula);
    }
}
