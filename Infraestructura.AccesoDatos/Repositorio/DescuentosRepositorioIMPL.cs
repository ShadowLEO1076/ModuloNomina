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
    public class DescuentosRepositorioIMPL : RepositorioImpl<Descuentos>, IDescuentosRepo
    {
        private readonly NominaDBContext _context;
        public DescuentosRepositorioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DescuentosEmpleadoDTO>> ObtenerDescuentosEmpleadoPorCedulaMesAnio(BusquedaDTO busquedaDTO)
        {
            try
            {
                var busq = await
                    _context.Descuentos.Include(d => d.Empleado)
                    .Where(d => (d.Fecha.Month == busquedaDTO.mes) && (d.Fecha.Year == busquedaDTO.anio) && (d.Empleado.Cedula == busquedaDTO.CedulaEmpleado) && (d.Estado == true))
                    .GroupBy(g => new
                    {
                        NombreCompleto = g.Empleado.Nombres + " " + g.Empleado.Apellidos,
                        Cedula = g.Empleado.Cedula,

                    }).Select(g => new DescuentosEmpleadoDTO
                    {
                        NombreCompleto = g.Key.NombreCompleto,
                        Cedula = g.Key.Cedula,
                        descuentos = g.Select(d => new DescuentosDTO
                        {
                            Descripcion = d.Descripcion,
                            Fecha = d.Fecha,
                            Monto = d.Monto,
                            Tipo = d.Tipo,
                        }).ToList()
                    }).ToListAsync();

                return busq;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error - DescuentosRepoImpl : no se pudo hallar los datos. {ex.Message}");
            }
        }
    }
}
