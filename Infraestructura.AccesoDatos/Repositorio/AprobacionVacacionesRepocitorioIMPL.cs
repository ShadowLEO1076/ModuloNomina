using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos.Abstracciones;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class AprobacionVacacionesRepocitorioIMPL : RepositorioImpl<AprobacionVacaciones>, IAprobacionVacacionesRepo
    {
        private readonly NominaDBContext _context;
        public AprobacionVacacionesRepocitorioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<AprobacionVacaciones>> BuscarPorEmpleadoAsync(int empleadoId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AprobacionVacaciones>> BuscarPorEmpleadoAsync(string cedula)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AprobacionVacaciones>> BuscarPorFechaAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistePorEmpleadoAsync(int empleadoId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistePorEmpleadoAsync(string cedula)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistePorFechaAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
