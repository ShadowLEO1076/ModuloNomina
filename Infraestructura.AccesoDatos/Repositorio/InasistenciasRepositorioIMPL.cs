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
    public class InasistenciasRepositorioIMPL : RepositorioImpl<Inasistencias>, IInasistenciasRepo
    {
        private readonly NominaDBContext _context;
        public InasistenciasRepositorioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inasistencias>> BuscarPorCedulaAsync(string cedula)
        {
            try 
            {
                var busq =
                    _context.Inasistencias.Include(i => i.Empleado).
                    Where(i => (i.Empleado.Cedula == cedula)).ToListAsync();

                return await busq;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - InasistenciasRepositorioImpl : {ex.Message}");
            }
        }

        public async Task<Inasistencias> BuscarPorIdYFecha(VerificarAsisInasisDTO dato)
        {
            try
            {
                var busq = await _context.Inasistencias.Where(i => (i.EmpleadoId == dato.idEmpleado) && (i.Fecha == dato.fechaVerificacion) && i.Estado == true)
                    .FirstOrDefaultAsync();

                return busq;
            }
            catch (Exception ex) { throw new Exception($"Error - AsistenciaRepoImpl : no se pudo encontrar el dato. {ex.Message}"); }

        }

        public async Task<List<InasistenciasEmpleadoDTO>> ObtenerInasistenciasPorCedulaMesAnio(BusquedaDTO busquedaDTO) // esta no 
        {
            try
            {
                var busq =
                     _context.Inasistencias.Include(i => i.Empleado).Include(i=> i.Licencia)
                     .Where(i => (i.Fecha.Month == busquedaDTO.mes) && (i.Fecha.Year == busquedaDTO.anio))
                     .GroupBy(g => new
                     {
                         NombresCompletos = g.Empleado.Nombres + " " + g.Empleado.Apellidos,
                         Cedula = g.Empleado.Cedula
                     })
                     .Select(i => new InasistenciasEmpleadoDTO
                     {

                         NombresCompletos = i.Key.NombresCompletos,
                         CedulaEmpleado = i.Key.Cedula,

                         inasistencias = i.Select(g => new InasistenciasDTO
                         {
                             Fecha = g.Fecha,
                             //DiasContados = g.DiasContados,
                             Remunerable = g.Licencia.Remunerable,
                         }).ToList()
                     }).ToListAsync();

                return await busq;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - InasistenciasRepositorioImpl : {ex.Message}");
            }
        }

        public async Task<IEnumerable<InasistenciasFormDTO>> ObtenerTodasActivasInasistenciasFormDTO()
        {
            try
            {
                //se debe traer SOLO los datos de los empleados activos. Y de ahí solo las asistencias activas
                var busq = _context.Inasistencias.Include(i => i.Empleado).Include(i => i.Licencia)
                    .Where(i => i.Empleado.Estado == true && i.Estado == true).Select(i => new InasistenciasFormDTO
                    {
                        IdInasistencias = i.IdInasistencia,
                        EmpleadoId = i.EmpleadoId,
                        NombresApellidos = i.Empleado.Nombres + " " + i.Empleado.Apellidos,
                        Cedula = i.Empleado.Cedula,
                        Fecha = i.Fecha,
                        Estado = i.Estado,
                        LicenciaId = i.LicenciaId,
                        NombreLicencia = i.Licencia.Nombre,
                        Remunerable = i.Licencia.Remunerable 
                    }).ToListAsync();

                return await busq;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - AsistenmciasRepoImpl : No se pudo hallar las asistencias solicitadas. {ex.Message}");
            }

        }
        public async Task<List<InasistenciasEmpleadoDTO>> ObtenerInasistenciasPorMesAnio(BusquedaDTO busquedaDTO)
        {
            try
            {
                var resultado =
                     _context.Inasistencias.Include(i => i.Empleado).Include(i => i.Licencia)
                     .Where(i => i.Fecha.Month == busquedaDTO.mes && i.Fecha.Year == busquedaDTO.anio)
                     .GroupBy(g => new
                     {
                         NombresCompletos = g.Empleado.Nombres + " " + g.Empleado.Apellidos,
                         Cedula = g.Empleado.Cedula
                     })
                     .Select(i => new InasistenciasEmpleadoDTO
                     {
                         NombresCompletos = i.Key.NombresCompletos,
                         CedulaEmpleado = i.Key.Cedula,
                         inasistencias = i.Select(g => new InasistenciasDTO
                         {
                             Fecha = g.Fecha,
                             Remunerable = g.Licencia.Remunerable,
                         }).ToList()
                     }).ToListAsync();

                return await resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - InasistenciasRepositorioImpl : {ex.Message}");
            }
        }

     
        
    }
}
