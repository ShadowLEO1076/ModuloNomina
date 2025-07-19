using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.AccesoDatos;


namespace Dominio.Modelos.Abstracciones
{
    public interface IAprobacionVacacionesRepo : IRepositorio<AprobacionVacaciones>
    {
        Task<IEnumerable<AprobacionVacaciones>> BuscarPorEmpleadoAsync(int empleadoId);
        Task<IEnumerable<AprobacionVacaciones>> BuscarPorEmpleadoAsync(string cedula);

        Task<IEnumerable<AprobacionVacaciones>> BuscarPorFechaAsync(DateTime fechaInicio, DateTime fechaFin);

        Task<bool> ExistePorEmpleadoAsync(int empleadoId);
        Task<bool> ExistePorEmpleadoAsync(string cedula);
        Task<bool> ExistePorFechaAsync(DateTime fechaInicio, DateTime fechaFin);


    }
}
