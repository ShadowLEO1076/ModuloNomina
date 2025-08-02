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
                    await _context.Empleados.Where(e => e.Cedula == cedula)  // cambie aqui Mateo porque tenia fecha fin y eso ya no existe te dejo para revision no borre nada cambie fecha fin por estado y comente lo otro
                    .Select(e => new EmpleadoContratoDTO
                    {
                        NombresEmple = e.Nombres,
                        ApellidosEmple = e.Apellidos,
                        CedulaEmple = e.Cedula,
                        FechaIngresoEmple = e.FechaIngreso,
                        EstadoEmple = e.Estado,

                        FechaInicioContra = e.Contratos.Where(c => (c.FechaInicio <= hoy) && (c.Estado == "Vigente"))
                      .Select(c => c.FechaInicio).FirstOrDefault(),

                       /* FechaFinContra = e.Contratos.Where(c => (c.FechaInicio <= hoy) && (c.Estado == "Vigente"))
                      .Select(c => c.FechaFin).FirstOrDefault(),*/

                        EstadoContra = e.Contratos.Where(c => (c.FechaInicio <= hoy) && (c.Estado == "Vigente"))
                      .Select(c => c.Estado).FirstOrDefault(),

                        SalarioContra = e.Contratos.Where(c => (c.FechaInicio <= hoy) && (c.Estado == "Vigente"))
                      .Select(c => c.Salario).FirstOrDefault(),

                       /* HorasJornadasContra = e.Contratos.Where(c => (c.FechaInicio <= hoy) && (c.FechaFin >= hoy))
                      .Select(c => c.HorasJornada).FirstOrDefault(),*/

                        JornadaContra = e.Contratos.Where(c => (c.FechaInicio <= hoy) && (c.Estado == "Vigente"))
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
        public async Task<List<EmpleadoConSalarioDTO>> ListarEmpleadosConSalarioAsync()
        {
            return await _context.Empleados
                .Include(e => e.Puesto)
                .Select(e => new EmpleadoConSalarioDTO
                {
                    IdEmpleado = e.IdEmpleado,
                    NombreCompleto = e.Nombres + " " + e.Apellidos,
                    PuestoId = e.PuestoId,
                    NombrePuesto = e.Puesto.Nombre,
                    SalarioBase = e.Puesto.SalarioBase
                })
                .ToListAsync();
        }
    }
}
