using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.AccesoDatos;


namespace Dominio.Modelos.Abstracciones
{
    public interface IContratosRepo : IRepositorio<Contratos>
    {
       
        Task<IEnumerable<Contratos>> BuscarPorEmpleadoAsync(string cedula); // Método para buscar contratos por empleado
        Task<IEnumerable<Contratos>> BuscarPorFechaAsync(DateTime fechaInicio, DateTime fechaFin); // Método para buscar contratos por rango de fechas contratos
        Task<bool> ExisteContratoPorEmpleadoAsync(string cedula); // Método para verificar si existe un contrato por empleado
        Task<bool> ExisteContratoPorFechaAsync(DateTime fechaInicio, DateTime fechaFin); // Método para verificar si existe un contrato por rango de fechas
    }
}
