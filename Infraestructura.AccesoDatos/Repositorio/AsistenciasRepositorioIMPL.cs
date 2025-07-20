using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos.Abstracciones;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class AsistenciasRepositorioIMPL : RepositorioImpl<Asistencias>, IAsistenciasRepo
    {
        private readonly NominaDBContext _dbContext;
        public AsistenciasRepositorioIMPL(NominaDBContext context) : base(context)
        {
            _dbContext = context;
        }

        public Task<IEnumerable<Asistencias>> BuscarPorCedulaAsync(string cedula)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Asistencias>> BuscarPorFechaAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
