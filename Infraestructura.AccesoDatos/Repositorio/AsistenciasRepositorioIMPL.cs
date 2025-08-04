using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Dominio.Modelos.Abstracciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class AsistenciasRepositorioIMPL : RepositorioImpl<Asistencias>, IAsistenciasRepo
    {
        private readonly NominaDBContext _context;
        public AsistenciasRepositorioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<AsistenciasEmpleadoDTO>> ObtenerAsistenciasPorCedulaMesAnio(BusquedaDTO busquedaDTO)
        {
            try
            {
                var busq =
                    _context.Asistencias.Include(a => a.Empleado)
                    .Where(a => (a.Fecha.Month == busquedaDTO.mes) && (a.Fecha.Year == busquedaDTO.anio))
                    .GroupBy(g => new
                    {
                        NombresCompletos = g.Empleado.Nombres + " " + g.Empleado.Apellidos,
                        Cedula = g.Empleado.Cedula
                    })
                    .Select(a => new AsistenciasEmpleadoDTO
                    {

                        NombreCompleto = a.Key.NombresCompletos,
                        Cedula = a.Key.Cedula,

                        Asistencias = a.Select(g => new AsistenciasDTO
                        {
                            Fecha = g.Fecha,
                            HoraEntrada = g.HoraEntrada,
                            HoraSalida = g.HoraSalida,
                        }).ToList()
                    }).ToListAsync();

                return await busq;
            }
            catch (Exception ex) 
            { 
                throw new Exception($"Error - AsistenciasRepoImpl : No se pudo hallar las asistencias del empleado con cedula"); 
            }
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<Asistencias>> BuscarPorCedulaAsync(string cedula)
        {
            try
            {
                var busq =
                    _context.Asistencias.Include(a => a.Empleado)
                    .Where(a => (a.Empleado.Cedula == cedula)).ToListAsync();

                return await busq;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - AsistenciasRepoImpl : No se pudo hallar las asistencias del empleado con cedula {cedula}. {ex.Message}");
            }
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<AsistenciasFormDTO>> ObtenerTodasActivasAsistenciasFormDTO()
        {
            try
            {
                //se debe traer SOLO los datos de los empleados activos. Y de ahí solo las asistencias activas
                var busq = _context.Asistencias.Include(a => a.Empleado)
                    .Where(a => a.Empleado.Estado == true && a.Estado == true).Select(a => new AsistenciasFormDTO
                    {
                        IdAsistencia = a.IdAsistencia,
                        EmpleadoId = a.EmpleadoId,
                        NombresApellidos = a.Empleado.Nombres + " " + a.Empleado.Apellidos,
                        Cedula = a.Empleado.Cedula,
                        Fecha = a.Fecha,
                        HoraEntrada = a.HoraEntrada,
                        HoraInicioAlmuerzo = a.HoraInicioAlmuerzo,
                        HoaFinAlmuerzo = a.HoaFinAlmuerzo,
                        HoraSalida = a.HoraSalida
                    }).ToListAsync();

                    return await busq;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - AsistenmciasRepoImpl : No se pudo hallar las asistencias solicitadas. {ex.Message}");
            }
        }

        public Task<IEnumerable<Asistencias>> BuscarPorFechaAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
        
        public async Task<Asistencias> BuscarPorIdYFecha(VerificarAsisInasisDTO dato)
        {
            
            // traer solo si el estado de la asistencia es activo, caso contrario, se puede ingresar
            try 
            { 
                var busq = await _context.Asistencias.Where(a => (a.EmpleadoId == dato.idEmpleado) && (a.Fecha == dato.fechaVerificacion) && a.Estado == true)
                    .FirstOrDefaultAsync();

                return busq;
            }
            catch (Exception ex) { throw new Exception($"Error - AsistenciaRepoImpl : no se pudo encontrar el dato. {ex.Message}"); }
            
        }
        
    }  
}
