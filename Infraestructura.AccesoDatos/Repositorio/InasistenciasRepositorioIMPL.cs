using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Dominio.Modelos.Abstracciones;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class InasistenciasRepositorioIMPL : RepositorioImpl<Inasistencias>, IInasistenciasRepo
    {
        private readonly NominaDBContext _context;
        public InasistenciasRepositorioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<Asistencias>> BuscarPorCedulaAsync(string cedula)
        {
            throw new NotImplementedException();
        }

        public Task<List<AsistenciasEmpleadoDTO>> ObtenerAsistenciasPorCedulaMesAnio(BusquedaDTO busquedaDTO)
        {
            throw new NotImplementedException();
        }

        public Task<List<AsistenciasEmpleadoDTO>> ObtenerInasistenciasPorCedulaMesAnio(BusquedaDTO busquedaDTO)
        {
            throw new NotImplementedException();
        }
    }
}
