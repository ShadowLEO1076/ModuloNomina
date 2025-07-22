using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos.Abstracciones;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class NominasRepositorioIMPL : RepositorioImpl<Nominas>, INominasRepo
    {
        private readonly NominaDBContext _context;
        public NominasRepositorioIMPL(NominaDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
