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
    public class EmpleadosServicioIMPL : ServicioIMPL<Empleados>, IEmpleadosServicio
    {
        private IEmpleadosRepo _repo;
        private readonly NominaDBContext _context;

        public EmpleadosServicioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
            _repo = new EmpleadosRepositorioIMPL(context);
        }
        public Task<Empleados> ObtenerEmpleadoPorCedulaAsync(string cedula)
        {
            throw new NotImplementedException();
        }

        
    }
}
