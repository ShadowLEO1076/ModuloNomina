using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.AccesoDatos;

namespace Aplicacion.Servicios
{
    public interface IBonificacionesServicio : IServicio<Bonificaciones>
    {
        // Aquí puedes definir métodos específicos para el servicio de bonificaciones
        // Por ejemplo:
        // Task<IEnumerable<Bonificaciones>> ObtenerBonificacionesPorEmpleadoAsync(int empleadoId);
        // Task<Bonificaciones> CalcularBonificacionAsync(int empleadoId, DateTime fecha);
    }
    
    
}
