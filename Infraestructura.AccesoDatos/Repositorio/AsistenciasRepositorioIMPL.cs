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
        public AsistenciasRepositorioIMPL(NominaDBContext context) : base(context)
        {
        }
    }
}
