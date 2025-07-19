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
    }
}
