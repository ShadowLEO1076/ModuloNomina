using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos.Abstracciones;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class ContratosRepositorioIMPL : RepositorioImpl<Contratos>, IContratosRepo
    {
        public ContratosRepositorioIMPL(NominaDBContext context) : base(context)
        {
        }

        public Task<IEnumerable<Contratos>> BuscarPorEmpleadoAsync(string cedula)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contratos>> BuscarPorFechaAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExisteContratoPorEmpleadoAsync(string cedula)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExisteContratoPorFechaAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
