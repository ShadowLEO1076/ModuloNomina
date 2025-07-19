using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos.Abstracciones;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class ParametrosRepositorioIMPL : RepositorioImpl<Parametros>, IParametrosRepo
    {
        public ParametrosRepositorioIMPL(NominaDBContext context) : base(context)
        {
        }
    }
}
