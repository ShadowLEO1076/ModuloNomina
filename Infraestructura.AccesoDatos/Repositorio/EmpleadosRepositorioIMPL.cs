using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Dominio.Modelos.Abstracciones;
using Microsoft.AspNetCore.Components.RenderTree;
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

        public async Task<Empleados> ObtenerEmpleadoPorCedulaAsync(string cedula)
        {
            try 
            {
                var busq =
                    await _context.Empleados.Where(e => e.Cedula == cedula).FirstOrDefaultAsync();

                return busq;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error - EmpleadosRepoImp : {ex.Message}");
            }
        }


        public async Task<EmpleadoContratoDTO> ObtenerEmpleadoDTOPorCedulaAsync(string cedula)
        {
            var hoy = DateOnly.FromDateTime(DateTime.Today);

            try
            {
                var empleadoBusq =
                    await _context.Empleados.Where(e => e.Cedula == cedula)
                    .Select(e => new EmpleadoContratoDTO
                    {
                        NombresEmple = e.Nombres,
                        ApellidosEmple = e.Apellidos,
                        CedulaEmple = e.Cedula,
                        FechaIngresoEmple = e.FechaIngreso,
                        EstadoEmple = e.Estado,

                        FechaInicioContra = e.Contratos.Where(c => (c.FechaInicio <= hoy) && ( c.FechaFin == null ||c.FechaFin >= hoy))
                      .Select(c => c.FechaInicio).FirstOrDefault(),

                        FechaFinContra = e.Contratos.Where(c => (c.FechaInicio <= hoy) && (c.FechaFin == null || c.FechaFin >= hoy))
                      .Select(c => c.FechaFin).FirstOrDefault(),

                        EstadoContra = e.Contratos.Where(c => (c.FechaInicio <= hoy) && (c.FechaFin == null || c.FechaFin >= hoy))
                      .Select(c => c.Estado).FirstOrDefault(),

                        SalarioContra = e.Contratos.Where(c => (c.FechaInicio <= hoy) && (c.FechaFin == null || c.FechaFin >= hoy))
                      .Select(c => c.Salario).FirstOrDefault(),

                        HorasJornadasContra = e.Contratos.Where(c => (c.FechaInicio <= hoy) && (c.FechaFin == null || c.FechaFin >= hoy))
                      .Select(c => c.HorasJornada).FirstOrDefault(),

                        JornadaContra = e.Contratos.Where(c => (c.FechaInicio <= hoy) && (c.FechaFin == null || c.FechaFin >= hoy))
                      .Select(c => c.Tipo.Jornada).FirstOrDefault()
                    }).SingleOrDefaultAsync();

                return empleadoBusq;
            }
            catch (Exception ex)
            {
                {

                    throw new Exception($"Error - EmpleadosRepoImpl : no se logró hallar el dato con la cédula {cedula}. {ex.Message} ");
                }

            }   

        }

        public async Task<IEnumerable<Empleados>> ObtenerTodosActivosAsync()
        {
            try
            {
                var busq =

                   await _context.Empleados.Where(e => e.Estado == true).ToListAsync();

                return busq;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al conseguir los datos: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Empleados>> ObtenerTodosInactivosAsync()
        {
            try
            {
                var busq =

                   await _context.Empleados.Where(e => e.Estado == false).ToListAsync();

                return busq;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al conseguir los datos: {ex.Message}");
            }
        }
    }
}
/* --> método de Guille.
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

            }*/