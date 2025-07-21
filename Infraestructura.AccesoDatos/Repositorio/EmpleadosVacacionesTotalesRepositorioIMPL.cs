using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos.Abstracciones;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class EmpleadosVacacionesTotalesRepositorioIMPL : RepositorioImpl<EmpleadosVacacionesTotales>
        , IEmpleadosVacacionesTotalesRepo
    {
        
        private readonly NominaDBContext _context;
        public EmpleadosVacacionesTotalesRepositorioIMPL(NominaDBContext context) : base(context)
        {
            this._context = context;
        }


        public async Task<IEnumerable<EmpleadosVacacionesTotales>> ObtenerConEmpleadoAsync()
        {
            return await _context.EmpleadosVacacionesTotales
                .Include(e => e.Empleado)
                .ToListAsync();
        }
        
    }
}
