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
    public class EmpleadosRepositorioIMPL : RepositorioImpl<Empleados>, IEmpleadosRepo
    {
        private readonly NominaDBContext _context;
        public EmpleadosRepositorioIMPL(NominaDBContext context) : base(context)
        {
            this._context = context;
        }

        public Task<Empleados> ObtenerEmpleadoPorCedulaAsync(string cedula)
        {
            throw new NotImplementedException();
        }

        
    }
}
