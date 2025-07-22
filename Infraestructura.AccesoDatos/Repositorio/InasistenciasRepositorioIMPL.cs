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

        public async Task<List<InasistenciasEmpleadoDTO>> ObtenerInasistenciasPorCedulaMesAnio(BusquedaDTO busquedaDTO)
        {
            try
            {
                var busq =
                     _context.Inasistencias.Include(i => i.Empleado).Include(i=> i.Licencia)
                     .Where(i => (i.Fecha.Month == busquedaDTO.mes) && (i.Fecha.Year == busquedaDTO.anio) && (i.Empleado.Cedula == busquedaDTO.CedulaEmpleado))
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
                             DiasContados = g.DiasContados,
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
    }
}
