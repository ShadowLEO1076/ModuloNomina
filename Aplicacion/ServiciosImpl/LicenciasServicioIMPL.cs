using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Servicios;
using Dominio.Modelos.Abstracciones;
using Infraestructura.AccesoDatos;
using Infraestructura.AccesoDatos.Repositorio;

namespace Aplicacion.ServiciosImpl
{
    public class LicenciasServicioIMPL : ServicioIMPL<Licencias>, ILicenciasServicio
    {
        private readonly ILicenciasRepo _repo;
        private readonly NominaDBContext _context;
        public LicenciasServicioIMPL(ILicenciasRepo repo,NominaDBContext context) : base(context)
        {
            _repo = repo;
            _context = context;
        }
    }
}
