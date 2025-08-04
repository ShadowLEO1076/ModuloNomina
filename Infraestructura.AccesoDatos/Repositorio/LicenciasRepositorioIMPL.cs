using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos.Abstracciones;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class LicenciasRepositorioIMPL : RepositorioImpl<Licencias>, ILicenciasRepo
    {
        private readonly NominaDBContext _context;    
        public LicenciasRepositorioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
