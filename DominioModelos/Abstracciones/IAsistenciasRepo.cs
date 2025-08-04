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
        //MÉTODO DE MATEO, si necesitan, copiar y reutilizar
        Task<List<AsistenciasEmpleadoDTO>> ObtenerAsistenciasPorCedulaMesAnio(NominasBusquedaDTO busquedaDTO);
        //usado para cálculos complejos
        Task<List<AsistenciasEmpleadoDTO>> ObtenerAsistenciasPorCedulaMesAnio(BusquedaDTO busquedaDTO);
        //el  métodos bnusca el DTO de todos los empleados activos, asegurando así que no veamos datos no deseados.
        Task<IEnumerable<AsistenciasFormDTO>> ObtenerTodasActivasAsistenciasFormDTO();
        Task<IEnumerable<Asistencias>> BuscarPorCedulaAsync(string cedula); // Método para buscar asistencias por cédula
        Task<IEnumerable<Asistencias>> BuscarPorFechaAsync(DateTime fechaInicio, DateTime fechaFin); // Método para buscar asistencias por rango de fechas
        //método para buscar si ya existe una asistencia solo usando la ID del empleado y la fecha de la asistencia
        Task<Asistencias> BuscarPorIdYFecha(VerificarAsisInasisDTO dato);

        
    }
}
