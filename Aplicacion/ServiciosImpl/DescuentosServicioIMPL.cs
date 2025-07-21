using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Aplicacion.Servicios;
using Dominio.Modelos.Abstracciones;
using Infraestructura.AccesoDatos;
using Infraestructura.AccesoDatos.Repositorio;

namespace Aplicacion.ServiciosImpl
{
    public class DescuentosServicioIMPL : ServicioIMPL<Descuentos>, IDescuentosServicio
    {
        private readonly NominaDBContext _context;
        private readonly IDescuentosRepo _repo;

        public DescuentosServicioIMPL(NominaDBContext context, IDescuentosRepo repo) : base(context)
        {
            _context = context;
            _repo = repo;
        }

        public async Task<List<DescuentosEmpleadoDTO>> ObtenerDescuentosEmpleadoPorCedulaMesAnio(BusquedaDTO busqueda)
        {
            try 
            {
                return await _repo.ObtenerDescuentosEmpleadoPorCedulaMesAnio(busqueda);
            }
            catch (Exception ex)  
            {
                throw new Exception($"Error - DescuentosServicioImpl : {ex.Message}"); 
            }
        }
    }
}
