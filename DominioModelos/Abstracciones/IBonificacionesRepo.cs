using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Infraestructura.AccesoDatos;




namespace Dominio.Modelos.Abstracciones
{
    public interface IBonificacionesRepo : IRepositorio<Bonificaciones>
    {
        // Método para obtener bonificaciones de empleados por año y mes
        Task<List<BonificacionesEmpleadoDTO>> ObtenerBonificacionesPorCedulaMesYAnio(BusquedaDTO datos);
        Task<IEnumerable<Bonificaciones>> ObtenerBonificacionesPorAnioMesAsync(int anio, int mes);
        Task<IEnumerable<Bonificaciones>> BuscarPorEmpleadoAsync(string cedula);// Método para buscar bonificaciones por empleado
        Task<IEnumerable<Bonificaciones>> BuscarPorFechaAsync(DateTime fechaInicio, DateTime fechaFin); // Método para buscar bonificaciones por rango de fechas
    }
}
