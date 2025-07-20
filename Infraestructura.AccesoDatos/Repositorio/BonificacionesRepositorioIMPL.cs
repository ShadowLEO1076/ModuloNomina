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
    public class BonificacionesRepositorioIMPL : RepositorioImpl<Bonificaciones>, IBonificacionesRepo
    {
        private readonly NominaDBContext _context;
        public BonificacionesRepositorioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<BonificacionesEmpleadoDTO>> ObtenerBonificacionesPorCedulaMesYAnio(BusquedaDTO datos)
        {
            try 
            {
                var busqueda = await
                    _context.Bonificaciones.Include(b => b.Empleado)
                    .Where(b => b.Empleado.Cedula == datos.CedulaEmpleado && b.Fecha.Month == datos.mes && b.Fecha.Year == datos.anio)
                    .GroupBy(b => new
                    {
                        NombreCompleto = b.Empleado.Nombres + " " + b.Empleado.Apellidos,
                        Cedula = b.Empleado.Cedula,
                    }).Select(g => new BonificacionesEmpleadoDTO
                    {
                        NombresCompletos = g.Key.NombreCompleto,
                        CedulaEmpleado = g.Key.Cedula,
                        bonificaciones = g.Select(b => new BonificacionesDTO
                        {
                            Fecha = b.Fecha,
                            Descripcion = b.Descripcion,
                            Monto = b.Monto,
                            Tipo = b.Tipo,
                        }).ToList()
                    }).ToListAsync();

                return busqueda;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error - BonificacionesRepoImpl : no se pudo hallar los datos con cédula {datos.CedulaEmpleado}. {ex.Message}");
            }
        }

        public Task<IEnumerable<Bonificaciones>> BuscarPorEmpleadoAsync(string cedula)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bonificaciones>> BuscarPorFechaAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bonificaciones>> ObtenerBonificacionesPorAnioMesAsync(int anio, int mes)
        {
            throw new NotImplementedException();
        }

      
    }
}
