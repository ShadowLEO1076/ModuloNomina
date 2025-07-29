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
    public class PuestosRepositorioIMPL : RepositorioImpl<Puestos>, IPuestosRepo
    {
       
        private readonly NominaDBContext _context;
        public PuestosRepositorioIMPL(NominaDBContext context) : base(context)
        {
            this._context = context;
        }
        
        // lo de arriba pero quiero buscar por puestos nombre:
        public async Task<IEnumerable<PuestosEmpleadoDTO>> BuscarPorPuestoAsync(string puestoNombre)
        {
            try
            {
                var empleados = await _context.Empleados
                    .Where(e => e.Puesto.Nombre.Contains(puestoNombre))
                    .Select(e => new PuestosEmpleadoDTO
                    {
                        NombreCompleto = e.Nombres + " " + e.Apellidos,
                        Cedula = e.Cedula,
                        NombrePuesto = e.Puesto.Nombre,
                        Correo  =e.Correo,
                        Telefono= e.Telefono,
                    })
                    .ToListAsync();
                return empleados;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar empleados por puesto: {ex.Message}");
            }
        }



    }
}
