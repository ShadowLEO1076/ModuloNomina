using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Infraestructura.AccesoDatos;


namespace Dominio.Modelos.Abstracciones
{
    public interface IAsistenciasRepo : IRepositorio<Asistencias>
    {
        Task<List<AsistenciasEmpleadoDTO>> ObtenerAsistenciasPorCedulaMesAnio(BusquedaDTO busquedaDTO);
        Task<IEnumerable<Asistencias>> BuscarPorCedulaAsync(string cedula); // Método para buscar asistencias por cédula
        Task<IEnumerable<Asistencias>> BuscarPorFechaAsync(DateTime fechaInicio, DateTime fechaFin); // Método para buscar asistencias por rango de fechas
    }
}
