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
    public class SaldoVacacionesRepositorioIMPL : RepositorioImpl<SaldoVacaciones>, ISaldoVacacionesRepo
    {
        private readonly NominaDBContext _context;
        public SaldoVacacionesRepositorioIMPL(NominaDBContext context) : base(context)
        {
            this._context = context;

        }

        public async Task<SaldoVacaciones> BuscarPorEmpleadoIdAsync(int empleadoId)
        {
            try
            {
                return await _context.SaldoVacaciones
            .FirstOrDefaultAsync(s => s.IdEmpleado == empleadoId);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, logging, etc.
                throw new NotImplementedException("ERROR AL OBTENER POR ID", ex);
            }
        }
        
    }
}
