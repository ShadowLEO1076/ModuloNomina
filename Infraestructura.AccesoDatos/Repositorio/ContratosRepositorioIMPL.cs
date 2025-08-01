using Aplicacion.DTO.DTOs;
using Dominio.Modelos.Abstracciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class ContratosRepositorioIMPL : RepositorioImpl<Contratos>, IContratosRepo
    {

        private readonly NominaDBContext _context;
        public ContratosRepositorioIMPL(NominaDBContext context) : base(context)
        {
            this._context = context;
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
                        EmpleadoId = c.EmpleadoId,
                        CedulaEmpleado = c.Empleado.Cedula,
                        NombreCompletoEmpleado = c.Empleado.Nombres + " " + c.Empleado.Apellidos,
                        TipoContrato = c.Tipo.Nombre,
                        DescripcionTipoContrato = c.Tipo.Jornada,
                        FechaInicio = c.FechaInicio,
                        JornadaHoraInicio = c.JornadaHoraInicio,
                        JornadaHoraFin = c.JornadaHoraFin,
                        FechaCreacion = c.FechaCreacion,
                        FechaModificacion = c.FechaCreacion,
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
                        FechaInicio = c.FechaInicio,
                        //FechaFin = c.FechaFin.HasValue ? c.FechaFin.Value.ToDateTime(TimeOnly.MinValue) : DateTime.MinValue,
                        Salario = c.Salario,
                        //Estado = c.FechaFin.HasValue && c.FechaFin.Value.ToDateTime(TimeOnly.MinValue) < DateTime.Today   ?  "Vencido" : "Vigente"
                    })
                    .ToListAsync();   
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener contratos para el empleado con cédula {cedula}", ex);
            }
        }

        
        // 🚨 NUEVO: Trae contratos vencidos (FechaFin < hoy y no están finalizados)
        public async Task<List<Contratos>> ObtenerContratosVencidosAsync()
        {
            try
            {
                return await _context.Contratos
                    .Where(c => c.Estado != "Finalizado")

                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener contratos vencidos", ex);
            }
        }

        // 🛠️ NUEVO: Actualiza un contrato (usado para marcar como finalizado)
        public async Task ActualizarContratoAsync(Contratos contrato)
        {
            try
            {
                _context.Contratos.Update(contrato);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar contrato", ex);
            }
        }

        public async Task<Contratos> ObtenerContratoActivoPorCedulaAsync(string cedula)
        {
            try
            {
                var hoy = DateOnly.FromDateTime(DateTime.Today);

                var busq = await _context.Contratos.Include(e => e.Empleado).Where(c => 
                (c.Empleado.Cedula == cedula) && (c.FechaInicio <= hoy) && (c.FechaFin == null || c.FechaFin >= hoy)).FirstOrDefaultAsync();

                return busq;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - ContratosRepoImpl : {ex.Message}");
            }
        }
    }
}



        
   
