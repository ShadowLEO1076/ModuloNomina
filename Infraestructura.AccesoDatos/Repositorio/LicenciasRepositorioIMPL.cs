using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos.Abstracciones;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class LicenciasRepositorioIMPL : RepositorioImpl<Licencias>, ILicenciasRepo
    {
        public LicenciasRepositorioIMPL(NominaDBContext context) : base(context)
        {
        }
    }
}
