using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Dominio.Modelos.Abstracciones;
using Infraestructura.AccesoDatos;
using Infraestructura.AccesoDatos.Repositorio;

namespace Aplicacion.ServiciosImpl
{
    public class EmpleadosVacacionesTotalesServicioIMPL : ServicioIMPL<EmpleadosVacacionesTotales>, IEmpleadosVacacionesTotalesServicio
    {

        private IEmpleadosVacacionesTotalesRepo _repo;
        private readonly NominaDBContext _context;

        public EmpleadosVacacionesTotalesServicioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
            _repo = new EmpleadosVacacionesTotalesRepositorioIMPL(context);
        }

        
        public async  Task<IEnumerable<EmpleadosVacacionesTotales>> ObtenerConEmpleadoAsync()
        {
            try
            {
                return await _repo.ObtenerConEmpleadoAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los registros de empleados con vacaciones totales", ex);

            }
        }

        public async  Task<List<VacacionesAsignadasDTO>> AsignarVacacionesAnualesAsync()
        {
            var registros = await _repo.ObtenerConEmpleadoAsync();
            var resultado = new List<VacacionesAsignadasDTO>();

            foreach (var registro in registros)
            {
                int otorgadosAntes = registro.DiasOtorgados;
                int otorgadosNuevo = registro.CalcularDiasOtorgados();

                if (otorgadosAntes != otorgadosNuevo)
                {
                    registro.DiasOtorgados = otorgadosNuevo;
                    await _repo.ActualizarAsync(registro);
                }

                resultado.Add(new VacacionesAsignadasDTO
                {
                    NombreEmpleado = $"{registro.Empleado.Nombres} {registro.Empleado.Apellidos}",
                    FechaIngreso = registro.Empleado.FechaIngreso,
                    DiasOtorgadosAntes = otorgadosAntes,
                    DiasOtorgadosNuevo = otorgadosNuevo,
                    DiasUsados = registro.DiasUsados
                });
            }

            return  resultado;
        }
    }
}
