using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Dominio.Modelos.Abstracciones;
using Microsoft.EntityFrameworkCore;
namespace Infraestructura.AccesoDatos.Repositorio
{
    public class EmpleadosRepositorioIMPL : RepositorioImpl<Empleados>, IEmpleadosRepo
    {
        private readonly NominaDBContext _context;
        public EmpleadosRepositorioIMPL(NominaDBContext context) : base(context)
        {
            this._context = context;
        }

        public Task<Empleados> ObtenerEmpleadoPorCedulaAsync(string cedula)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmpleadoVacacionesDTO>> ObtenerResumenVacacionesAsync() // Método para obtener un resumen de vacaciones de los empleados LEONARDO
        {
            try
            {
                // Consulta para obtener el resumen de vacaciones de los empleados
                var resumenVacaciones = await _context.Empleados
                    .Include(e => e.EmpleadosVacacionesTotales)
                    .Select(e => new EmpleadoVacacionesDTO
                    {
                        IdEmpleado = e.IdEmpleado,
                        NombresCompletos = e.Nombres + " " + e.Apellidos,
                        TotalVacaciones = e.EmpleadosVacacionesTotales.DiasOtorgados,
                        VacacionesDisponibles = e.EmpleadosVacacionesTotales.DiasUsados
                    })
                    .ToListAsync();
                return resumenVacaciones;

            }
            catch (Exception ex)
            {
                // Manejo de excepciones, logging, etc.
                throw new NotImplementedException("ERROR AL OBTENER RESUMEN DE VACACIONES", ex);
            }
        }
    }
}
