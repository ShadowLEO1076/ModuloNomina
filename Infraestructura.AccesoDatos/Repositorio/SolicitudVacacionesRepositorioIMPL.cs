using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos.Abstracciones;

namespace Infraestructura.AccesoDatos.Repositorio
{
    public class SolicitudVacacionesRepositorioIMPL : RepositorioImpl<SolicitudVacaciones>, ISolicitudVacacionesRepo
    {
        public SolicitudVacacionesRepositorioIMPL(NominaDBContext context) : base(context)
        {
        }
    }
}
