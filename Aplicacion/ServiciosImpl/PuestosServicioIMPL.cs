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
    public class PuestosServicioIMPL : ServicioIMPL<Puestos>, IPuestosServicio
    {
        
        private IPuestosRepo _repo;
        private readonly NominaDBContext _context;
        public PuestosServicioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
            _repo = new PuestosRepositorioIMPL(context);
        }
        public async Task<IEnumerable<PuestosEmpleadoDTO>> BuscarPorPuestoAsync(string puestoNombre)
        {
            try
            {
                return await _repo.BuscarPorPuestoAsync(puestoNombre);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error - EmpleadosServicioImpl : no se pudo hallar al empleado con el nombre {puestoNombre}. {ex.Message}");

            }
        }
    }
}
