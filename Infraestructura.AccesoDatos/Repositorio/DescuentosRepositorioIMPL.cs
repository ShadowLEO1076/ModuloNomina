using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos.Abstracciones;
namespace Infraestructura.AccesoDatos.Repositorio
{
    public class DescuentosRepositorioIMPL : RepositorioImpl<Descuentos>, IDescuentosRepo
    {
        public DescuentosRepositorioIMPL(NominaDBContext context) : base(context)
        {
        }
    }
}
