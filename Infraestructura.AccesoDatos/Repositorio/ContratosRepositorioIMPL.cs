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
    public class ContratosRepositorioIMPL : RepositorioImpl<Contratos>, IContratosRepo
    {

        private readonly NominaDBContext _context;
        public ContratosRepositorioIMPL(NominaDBContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Contratos>> BuscarPorFechaAsync(DateOnly fechaInicio, DateOnly fechaFin)
        {
            try
            {
                return await _context.Contratos
                    .Where(c => c.FechaInicio >= fechaInicio && (c.FechaFin == null || c.FechaFin <= fechaFin))
                    .ToListAsync();
                // va a listar todos los contratos que tengan una fecha de inicio dentro del rango especificado
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar contratos por fecha", ex);
            }
            
        }

        public async Task<List<ContratoDTO>> ObtenerContratosCompletosAsync()
        {
            try
            {
                return await _context.Contratos
                    .Include(c => c.Empleado)
                    .Include(c => c.Tipo)
                    .Select(c => new ContratoDTO
                    {
                        IdContrato = c.IdContrato,
                        CedulaEmpleado = c.Empleado.Cedula,
                        NombreCompletoEmpleado = c.Empleado.Nombres + " " + c.Empleado.Apellidos,
                        TipoContrato = c.Tipo.Nombre,
                        DescripcionTipoContrato = c.Tipo.Jornada,
                        FechaInicio = c.FechaInicio.ToDateTime(TimeOnly.MinValue),
                        FechaFin = c.FechaFin.HasValue ? c.FechaFin.Value.ToDateTime(TimeOnly.MinValue) : DateTime.MinValue,
                        Salario = c.Salario,
                        Estado = c.Estado
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener contratos completos", ex);
            }
        }

        public async Task<List<ContratoDTO>> ObtenerContratosPorEmpleadoAsync(string cedula)
        {
            try
            {
                return await _context.Contratos
                    .Include(c => c.Empleado)
                    .Include(c => c.Tipo)
                    .Where(c => c.Empleado.Cedula == cedula)
                    .OrderByDescending(c => c.FechaInicio) // Ordenar por fecha más reciente
                    .Select(c => new ContratoDTO
                    {
                        IdContrato = c.IdContrato,
                        CedulaEmpleado = c.Empleado.Cedula,
                        NombreCompletoEmpleado = $"{c.Empleado.Nombres} {c.Empleado.Apellidos}",
                        TipoContrato = c.Tipo.Nombre,
                        DescripcionTipoContrato = c.Tipo.Jornada,
                        FechaInicio = c.FechaInicio.ToDateTime(TimeOnly.MinValue),
                        FechaFin = c.FechaFin.HasValue ? c.FechaFin.Value.ToDateTime(TimeOnly.MinValue) : DateTime.MinValue,
                        Salario = c.Salario,
                        Estado = c.FechaFin.HasValue && c.FechaFin.Value.ToDateTime(TimeOnly.MinValue) < DateTime.Today   ?  "Vencido" : "Vigente"
                    })
                    .ToListAsync();   
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener contratos para el empleado con cédula {cedula}", ex);
            }
        }

        public async Task<List<ContratoDTO>> ObtenerContratosVigentesAsync(DateTime fecha)
        {
            try
            {
                return await _context.Contratos
                    
                    .Where(c => c.FechaFin == null || c.FechaFin.Value.ToDateTime(TimeOnly.MinValue) >= fecha)
                    .Include(c => c.Empleado)
                    .Include(c => c.Tipo)
                    .Select(c => new ContratoDTO
                    {
                        // Mapeo similar
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener contratos vigentes para fecha {fecha}", ex);
            }
        }
    }
}
