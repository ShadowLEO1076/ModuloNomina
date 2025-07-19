using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.AccesoDatos;

namespace Aplicacion.Servicios
{
    public interface IAprobacionVacacionesServicio :IServicio<AprobacionVacaciones>
    {
        // en teoria ya tiene metodos crud de Irepositorio por Herencia
    }
}
