using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos.Abstracciones;


namespace Infraestructura.AccesoDatos.Repositorio
{
    public class BonificacionesRepositorioIMPL : RepositorioImpl<Bonificaciones>, IBonificacionesRepo
    {
        public BonificacionesRepositorioIMPL(NominaDBContext context) : base(context)
        {
        }

        public Task<IEnumerable<Bonificaciones>> BuscarPorEmpleadoAsync(string cedula)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bonificaciones>> BuscarPorFechaAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bonificaciones>> ObtenerBonificacionesPorAnioMesAsync(int anio, int mes)
        {
            throw new NotImplementedException();
        }
    }
}
