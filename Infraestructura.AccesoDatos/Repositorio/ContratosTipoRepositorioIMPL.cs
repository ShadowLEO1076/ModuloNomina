using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos.Abstracciones;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class ContratosTipoRepositorioIMPL : RepositorioImpl<ContratosTipo>, IContratosTipoRepo
    {
        public ContratosTipoRepositorioIMPL(NominaDBContext context) : base(context)
        {
        }
    }
}
